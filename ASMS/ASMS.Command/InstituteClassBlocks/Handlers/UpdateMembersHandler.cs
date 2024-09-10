using ASMS.Command.InstituteClassBlocks.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Command.InstituteClassBlocks.Handlers
{
    public class UpdateMembersHandler : IRequestHandler<UpdateMembers, BaseApiResponse<bool>>
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;
        private readonly IInstituteMemberService _instituteMemberService;
        private readonly ClassStatus[] notActiveStatus = { ClassStatus.Cancelled, ClassStatus.Finished };

        public UpdateMembersHandler(IInstituteClassBlockService instituteClassBlockService,
                                    IInstituteMemberService instituteMemberService)
        {
            _instituteClassBlockService = instituteClassBlockService;
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<bool>> Handle(UpdateMembers request, CancellationToken cancellationToken)
        {
            var entity = await _instituteClassBlockService.TryGetExistentEntityAsync(request.Id, GetIncludeQuery());

            await BasicValidation(request, entity);

            var existentMemberIds = entity.InstituteMembers.Select(x => x.InstituteMemberId);

            var toDeleteMembers = await ReturnClassForMembersToBeRemoved(request.MembersId, entity, existentMemberIds);

            var toAddMembers = await HandleNewMembersToAddInClass(request.MembersId, entity, existentMemberIds);

            SetMembersIntoClassAndUpdateStatus(request, entity, toDeleteMembers, toAddMembers);

            var response = await _instituteClassBlockService.UpdateEntityAsync(entity);

            return new BaseApiResponse<bool>(response);
        }

        private async Task BasicValidation(UpdateMembers request, InstituteClassBlock entity)
        {
            if (entity.StartDateTime <= DateTime.UtcNow)
                throw new BadRequestException("You cannot update members from a class that it's already finished");

            if (notActiveStatus.Contains(entity.ClassStatus))
                throw new BadRequestException("You cannot add members to an inactive class");

            if (request.MembersId.Count > entity.Room.MembersCapacity)
                throw new BadRequestException("You don't have capacity on room");

            var existMembers = await _instituteMemberService.ExistIdsAsync(request.MembersId);

            if (!existMembers)
                throw new BadRequestException("Some of the institute members you're trying to assign don't exist");
        }

        private async Task<IEnumerable<InstituteMember>> ReturnClassForMembersToBeRemoved(IEnumerable<long> newMembersId, InstituteClassBlock entity, IEnumerable<long> existentMemberIds)
        {
            var toRemoveMemberIds = existentMemberIds.Except(newMembersId);

            var toReturnClassMembers = await _instituteMemberService.GetEntityListAsync(x => toRemoveMemberIds.Contains(x.Id) &&
                                                                                             x.Memberships.SingleOrDefault(x => x.IsActiveMembership) != null &&
                                                                                             x.Memberships.SingleOrDefault(x => x.IsActiveMembership)!.Membership.MembershipType.IsByQuantity,
                                                                                             GetIncludeForInstituteMembersToRemove());

            foreach (var member in toReturnClassMembers)
                member.ActiveMembership!.RemainingClasses++;

            return toReturnClassMembers.ToList();
        }

        private async Task<IEnumerable<InstituteMember>> HandleNewMembersToAddInClass(IEnumerable<long> newMembersId, InstituteClassBlock entity, IEnumerable<long> existentMemberIds)
        {
            var toAddMemberIds = newMembersId.Except(existentMemberIds);

            var toAddInClass = await _instituteMemberService.GetEntityListAsync(x => toAddMemberIds.Contains(x.Id), GetIncludeForInstituteMembers());

            ValidateDisabledMembers(toAddInClass);

            ValidateMembersWithInactiveMembership(toAddInClass);

            ValidateUsersWithNoPremiumMembership(entity, toAddInClass);

            DiscountClassForMembersWithByQuantityMembership(toAddInClass);

            return toAddInClass;
        }

        private static void ValidateDisabledMembers(IList<InstituteMember> toAddInClass)
        {
            var disabledMembers = toAddInClass.Where(x => !x.IsEnabled);

            if (disabledMembers.Any())
            {
                var names = disabledMembers.Select(x => $"{x.User.LastName}, {x.User.FirstName}");
                throw new BadRequestException($"The members ({string.Join(",", names)}) are blocked");
            }
        }

        private static void ValidateMembersWithInactiveMembership(IList<InstituteMember> toAddInClass)
        {
            var userWithoutActiveMembership = toAddInClass.Where(x => x.ActiveMembership == null || x.ActiveMembership.NeedToPay);

            if (userWithoutActiveMembership.Any())
            {
                var names = userWithoutActiveMembership.Select(x => $"{x.User.LastName}, {x.User.FirstName}");
                throw new BadRequestException($"The members ({string.Join(",", names)}) don't have active membership");
            }
        }

        private static void ValidateUsersWithNoPremiumMembership(InstituteClassBlock entity, IList<InstituteMember> toAddInClass)
        {
            var notPremiumUsers = toAddInClass.Where(x => !x.ActiveMembership!.Membership.IsPremium &&
                                                          !x.AllowedActivities.Select(x => x.ActivityId).Contains(entity.ActivityId));

            if (notPremiumUsers.Any())
            {
                var names = notPremiumUsers.Select(x => $"{x.User.LastName}, {x.User.FirstName}");
                throw new BadRequestException($"The members ({string.Join(",", names)}) don't have the activity {entity.Activity.Name} allowed");
            }
        }

        private static void DiscountClassForMembersWithByQuantityMembership(IList<InstituteMember> toAddInClass)
        {
            var toDiscountPendingClass = toAddInClass.Where(x => x.ActiveMembership!.Membership.MembershipType.IsByQuantity);

            if (toDiscountPendingClass.Any())
            {
                foreach (var member in toDiscountPendingClass)
                    member.ActiveMembership!.RemainingClasses--;
            }
        }

        private static void SetMembersIntoClassAndUpdateStatus(UpdateMembers request,
                                                               InstituteClassBlock entity,
                                                               IEnumerable<InstituteMember> toRemoveMembers,
                                                               IEnumerable<InstituteMember> toAddMembers)
        {
            if (toRemoveMembers.Any())
            {
                foreach (var member in toRemoveMembers)
                {
                    var instituteMember = entity.InstituteMembers.SingleOrDefault(x => x.InstituteMemberId == member.Id);

                    if (instituteMember != null)
                        entity.InstituteMembers.Remove(instituteMember);
                }
            }

            if (toAddMembers.Any())
            {
                foreach (var member in toAddMembers)
                {
                    entity.InstituteMembers.Add(new InstituteMemberInstituteClassBlock
                    {
                        InstituteMemberId = member.Id,
                        InstituteMember = member,
                    });
                }
            }

            entity.ClassStatus = entity.InstituteMembers.Count < entity.Header.Activity.MemberMinQuantity ? ClassStatus.Pending : ClassStatus.Active;
        }

        private static Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>> GetIncludeForInstituteMembers()
        {
            return x => x.Include(x => x.AllowedActivities)
                         .Include(x => x.Memberships)
                         .ThenInclude(x => x.Membership)
                         .ThenInclude(x => x.MembershipType)
                         .Include(x => x.Memberships)
                         .ThenInclude(x => x.Payments)
                         .Include(x => x.User);
        }

        private static Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>> GetIncludeForInstituteMembersToRemove()
        {
            return x => x.Include(x => x.Memberships)
                         .ThenInclude(x => x.Membership)
                         .ThenInclude(x => x.MembershipType);
        }

        private static Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>> GetIncludeQuery()
        {
            return x => x.Include(x => x.Header)
                         .ThenInclude(x => x.Activity)
                         .Include(x => x.Room)
                         .Include(x => x.InstituteMembers);
        }
    }
}