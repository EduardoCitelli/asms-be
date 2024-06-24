using ASMS.Command.Payments.Commands;
using ASMS.Domain.Entities;
using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Command.Payments.Handlers
{
    public class CreateForcePaymentHandler : IRequestHandler<CreateForcePayment, BaseApiResponse<PaymentSingleDto>>
    {
        private readonly IPaymentService _service;
        private readonly IInstituteMemberService _instituteMemberService;
        private readonly IInstituteMemberMembershipService _instituteMemberMembershipService;

        public CreateForcePaymentHandler(IPaymentService service,
                                         IInstituteMemberService instituteMemberService,
                                         IInstituteMemberMembershipService instituteMemberMembershipService)
        {
            _service = service;
            _instituteMemberService = instituteMemberService;
            _instituteMemberMembershipService = instituteMemberMembershipService;
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> Handle(CreateForcePayment request, CancellationToken cancellationToken)
        {
            await _instituteMemberService.ValidateExistingAsync(request.InstituteMemberId);

            var instituteMemberMembership = await _instituteMemberMembershipService.GetEntityActiveByInstituteMemberAsync(request.InstituteMemberId,
                                                                                                                          x => x.Include(x => x.Payments)
                                                                                                                                .Include(x => x.Membership)
                                                                                                                                .ThenInclude(x => x.MembershipType));

            var membership = ValidateAsync(request, instituteMemberMembership);

            await UpdateMembership(request, instituteMemberMembership, membership);

            return await _service.CreateAsync(request, SetInstituteMemberMembershipId(instituteMemberMembership.Id));
        }

        private static Membership ValidateAsync(CreateForcePayment request, InstituteMemberMembership instituteMemberMembership)
        {
            var membership = instituteMemberMembership.Membership;

            if (request.Amount < membership.Price)
            {
                var message = $"The remaining payment is $ {membership.Price}, and you are trying to pay $ {request.Amount}, you can make force payment just for the total";
                throw new BadRequestException(message);
            }

            return membership;
        }

        private async Task UpdateMembership(CreateForcePayment request, 
                                            InstituteMemberMembership instituteMemberMembership, 
                                            Membership membership)
        {
            instituteMemberMembership.LastFullPaymentDate = DateTime.UtcNow;
            instituteMemberMembership.RemainingClasses = membership.MembershipType.ClassQuantity;

            instituteMemberMembership.HandleExpirationDate(request.UpdateByExpirationDate);

            await _instituteMemberMembershipService.UpdateWithoutSaveAsync(instituteMemberMembership);
        }

        private static Action<Payment> SetInstituteMemberMembershipId(long instituteMemberMembershipId) =>
            x => x.InstituteMemberMembershipId = instituteMemberMembershipId;
    }
}
