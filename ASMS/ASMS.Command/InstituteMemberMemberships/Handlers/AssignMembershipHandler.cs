using ASMS.Command.InstituteMemberMemberships.Commands;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Command.InstituteMemberMemberships.Handlers
{
    public class AssignMembershipHandler : IRequestHandler<AssignMembershipCommand, BaseApiResponse<long>>
    {
        private readonly IInstituteMemberMembershipService _service;
        private readonly IMembershipService _membershipService;
        private readonly IInstituteMemberService _instituteMemberService;

        public AssignMembershipHandler(IInstituteMemberMembershipService service,
                                       IMembershipService membershipService,
                                       IInstituteMemberService instituteMemberService)
        {
            _service = service;
            _membershipService = membershipService;
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<long>> Handle(AssignMembershipCommand request, CancellationToken cancellationToken)
        {
            var membership = await _membershipService.GetEntityByIdAsync(request.MembershipId, x => x.Include(x => x.MembershipType));

            await RunValidations(request, membership);

            SetPaymentAmmountSameAsMembershipPrice(request, membership);

            await SetActivitiesToInstituteMember(request, membership);

            return await _service.CreateAsync(request, entity =>
            {
                HandleExpirationMembership(entity, membership);
            });
        }

        private static void HandleExpirationMembership(InstituteMemberMembership entity, Membership membership)
        {
            entity.ExpirationDate = entity.StartDate.AddMonths(membership.MembershipType.MonthQuantity);

            entity.RemainingClasses = membership.MembershipType.IsByQuantity ? membership.MembershipType.ClassQuantity : null;
        }

        private async Task RunValidations(AssignMembershipCommand request, Membership membership)
        {
            if (!membership.IsPremium)
            {
                if (request.Activities == null)
                    throw new BadRequestException("If membership is not premium you should define allowed activities");

                if (request.Activities.Count() > membership.ActivityQuantity)
                    throw new BadRequestException("The activities to add should be less than the allowed activities by the membership");
            }

            await _instituteMemberService.ValidateExistingAsync(request.InstituteMemberId);
        }

        private static void SetPaymentAmmountSameAsMembershipPrice(AssignMembershipCommand request, Membership membership)
        {
            if (request.Payment != null)
                request.Payment.Amount = membership.Price;
        }

        private async Task SetActivitiesToInstituteMember(AssignMembershipCommand request, Membership membership)
        {
            if (!membership.IsPremium)
                await _instituteMemberService.SetActivitiesToInstituteMemberWithoutSaveAsync(request.InstituteMemberId, request.Activities!);
        }
    }
}