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
    public class CreatePaymentHandler : IRequestHandler<CreatePayment, BaseApiResponse<PaymentSingleDto>>
    {
        private readonly IPaymentService _service;
        private readonly IInstituteMemberService _instituteMemberService;
        private readonly IInstituteMemberMembershipService _instituteMemberMembershipService;

        public CreatePaymentHandler(IPaymentService service,
                                    IInstituteMemberService instituteMemberService,
                                    IInstituteMemberMembershipService instituteMemberMembershipService)
        {
            _service = service;
            _instituteMemberService = instituteMemberService;
            _instituteMemberMembershipService = instituteMemberMembershipService;
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> Handle(CreatePayment request, CancellationToken cancellationToken)
        {
            await _instituteMemberService.ValidateExistingAsync(request.InstituteMemberId);

            var instituteMemberMembership = await GetMemberActiveMembership(request);

            var membership = ValidateAsync(request, instituteMemberMembership);

            await UpdateMembershipForFullPayment(request, instituteMemberMembership, membership);

            return await _service.CreateAsync(request, SetInstituteMemberMembershipId(instituteMemberMembership.Id));
        }

        private async Task<InstituteMemberMembership> GetMemberActiveMembership(CreatePayment request)
        {
            return await _instituteMemberMembershipService.GetEntityActiveByInstituteMemberAsync(request.InstituteMemberId,
                                                                                                 x => x.Include(x => x.Payments)
                                                                                                       .Include(x => x.Membership)
                                                                                                       .ThenInclude(x => x.MembershipType));
        }

        private static Membership ValidateAsync(CreatePayment request, InstituteMemberMembership instituteMemberMembership)
        {
            var membership = instituteMemberMembership.Membership;

            if (instituteMemberMembership.LastFullPaymentDate == null && request.Amount < membership.Price)
                throw new BadRequestException("The first payment should be the total price of the membership");

            if (instituteMemberMembership.RemainingPayment < request.Amount)
                throw new BadRequestException($"The remaining payment is $ {instituteMemberMembership.RemainingPayment}, and you are trying to pay $ {request.Amount}");

            return instituteMemberMembership.NeedToPay ? membership
                                                       : throw new BadRequestException($"Membership for user already paid and it is not expired");
        }

        private async Task UpdateMembershipForFullPayment(CreatePayment request, InstituteMemberMembership instituteMemberMembership, Membership membership)
        {
            if (IsFullPayment(request, instituteMemberMembership))
            {
                instituteMemberMembership.LastFullPaymentDate = DateTime.UtcNow;                
                instituteMemberMembership.RemainingClasses = membership.MembershipType.ClassQuantity;

                instituteMemberMembership.HandleExpirationDate(request.UpdateByExpirationDate);

                await _instituteMemberMembershipService.UpdateWithoutSaveAsync(instituteMemberMembership);
            }
        }

        private static bool IsFullPayment(CreatePayment request, InstituteMemberMembership instituteMemberMembership) =>
            request.Amount >= instituteMemberMembership.RemainingPayment;

        private static Action<Payment> SetInstituteMemberMembershipId(long instituteMemberMembershipId) =>
            x => x.InstituteMemberMembershipId = instituteMemberMembershipId;
    }
}