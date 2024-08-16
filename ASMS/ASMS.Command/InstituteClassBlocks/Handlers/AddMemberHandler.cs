using ASMS.Command.InstituteClassBlocks.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Services.Models;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Command.InstituteClassBlocks.Handlers
{
    public class AddMemberHandler : IRequestHandler<AddMember, BaseApiResponse<bool>>
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IInstituteClassBlockService _instituteClassBlockService;
        private readonly IInstituteMemberService _instituteMemberService;

        public AddMemberHandler(IUserInfoService userInfoService, 
                                IInstituteClassBlockService instituteClassBlockService,                                
                                IInstituteMemberService instituteMemberService)
        {
            _userInfoService = userInfoService;
            _instituteClassBlockService = instituteClassBlockService;
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<bool>> Handle(AddMember request, CancellationToken cancellationToken)
        {
            var user = _userInfoService.Value ?? throw new BadRequestException($"User doesn't exist");
            var entity = await _instituteClassBlockService.TryGetExistentEntityAsync(request.Id, GetIncludeQuery());

            RunInstituteClassValidations(entity, user);

            var member = await _instituteMemberService.GetEntityByIdAsync(user.Id, GetIncludeForInstituteMembers());

            RunInstituteMemberValidations(entity, member);
            AddMemberToClassAndUpdateStatus(entity, member);

            var response = await _instituteClassBlockService.UpdateEntityAsync(entity);
            return new BaseApiResponse<bool>(response);
        }

        private static void RunInstituteClassValidations(InstituteClassBlock entity, UserInfo user)
        {
            if (entity.InstituteMembers.Any(x => x.Id == user.Id))
                throw new BadRequestException($"You're trying to assign an existent member to the class");

            if (entity.Room.MembersCapacity < entity.InstituteMembers.Count + 1)
                throw new BadRequestException($"The room is full");
        }

        private static void RunInstituteMemberValidations(InstituteClassBlock entity, InstituteMember member)
        {
            if (!member.IsEnabled)
                throw new BadRequestException($"The member is blocked");

            if (member.ActiveMembership == null || member.ActiveMembership.NeedToPay)
                throw new BadRequestException("The member doesn't have an active membership");

            if (!member.ActiveMembership.Membership.IsPremium && !member.AllowedActivities.Select(x => x.Id).Contains(entity.ActivityId))
                throw new BadRequestException($"The member doesn't have the activity {entity.Activity.Name} allowed");

            if (member.ActiveMembership.Membership.MembershipType.IsByQuantity)
                member.ActiveMembership.RemainingClasses--;
        }

        private static void AddMemberToClassAndUpdateStatus(InstituteClassBlock entity, InstituteMember member)
        {
            entity.InstituteMembers.Add(new InstituteMemberInstituteClassBlock
            {
                InstituteMemberId = member.Id,
                InstituteMember = member,
            });

            entity.ClassStatus = entity.InstituteMembers.Count < entity.Activity.MemberMinQuantity ? ClassStatus.Pending : ClassStatus.Active;
        }

        private static Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>> GetIncludeForInstituteMembers()
        {
            return x => x.Include(x => x.AllowedActivities)
                         .Include(x => x.Memberships)
                         .ThenInclude(x => x.Membership)
                         .ThenInclude(x => x.MembershipType)
                         .Include(x => x.Memberships)
                         .ThenInclude(x => x.Payments);
        }

        private static Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>> GetIncludeQuery()
        {
            return x => x.Include(x => x.Header)
                         .Include(x => x.Room)
                         .Include(x => x.InstituteMembers)
                         .ThenInclude(x => x.InstituteMember)
                         .ThenInclude(x => x.Memberships)
                         .ThenInclude(x => x.Membership)
                         .ThenInclude(x => x.MembershipType);
        }
    }
}