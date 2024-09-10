using ASMS.Command.InstituteMemberMemberships.Commands;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Command.InstituteMemberMemberships.Handlers
{
    public class UpdateMembershipHandler : IRequestHandler<UpdateMembershipCommand, BaseApiResponse<long>>
    {
        private readonly IInstituteMemberMembershipService _service;
        private readonly IMembershipService _membershipService;
        private readonly IInstituteMemberService _instituteMemberService;

        public UpdateMembershipHandler(IInstituteMemberMembershipService service,
                                       IMembershipService membershipService,
                                       IInstituteMemberService instituteMemberService)
        {
            _service = service;
            _membershipService = membershipService;
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<long>> Handle(UpdateMembershipCommand request, CancellationToken cancellationToken)
        {
            var membership = await _membershipService.GetEntityByIdAsync(request.MembershipId, x => x.Include(x => x.MembershipType));

            await RunValidations(request, membership);

            SetPaymentAmmountSameAsMembershipPrice(request, membership);

            await _service.SetInactiveMembershipsWithoutSave(request.InstituteMemberId);

            if (!membership.IsPremium)
                await _instituteMemberService.SetActivitiesToInstituteMemberWithoutSaveAsync(request.InstituteMemberId, request.Activities!);

            return await _service.CreateAsync(request, x =>
            {
                x.ExpirationDate = x.StartDate.AddMonths(membership.MembershipType.MonthQuantity);

                x.RemainingClasses = membership.MembershipType.IsByQuantity ? membership.MembershipType.ClassQuantity : null;
            });
        }

        private async Task RunValidations(UpdateMembershipCommand request, Membership membership)
        {
            if (!membership.IsPremium)
            {
                if (request.Activities == null)
                    throw new BadRequestException("If membership is not premium you should define allowed activities");

                if (request.Activities.Count() > membership.ActivityQuantity)
                    throw new BadRequestException("The activities to add should be less than the allowed activities by the membership");
            }

            await _service.ValidateTryToAssignSameMembership(request.InstituteMemberId, request.MembershipId);
            await _instituteMemberService.ValidateExistingAsync(request.InstituteMemberId);
        }

        private static void SetPaymentAmmountSameAsMembershipPrice(UpdateMembershipCommand request, Membership membership)
        {
            if (request.Payment != null)
                request.Payment.Amount = membership.Price;
        }
    }
}