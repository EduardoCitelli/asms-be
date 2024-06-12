using ASMS.Command.InstituteMemberMemberships.Commands;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
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
            await RunValidations(request);

            var membership = await _membershipService.GetEntityByIdAsync(request.MembershipId, x => x.Include(x => x.MembershipType));

            SetPaymentAmmountSameAsMembershipPrice(request, membership);

            await _service.SetInactiveMembershipsWithoutSave(request.InstituteMemberId);

            return await _service.CreateAsync(request, x =>
            {
                x.ExpirationDate = x.StartDate.AddMonths(membership.MembershipType.MonthQuantity);
            });
        }

        private async Task RunValidations(UpdateMembershipCommand request)
        {
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