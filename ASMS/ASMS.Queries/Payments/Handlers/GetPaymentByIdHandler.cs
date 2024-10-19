using ASMS.Domain.Entities;
using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using ASMS.Queries.Payments.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Queries.Payments.Handlers
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentById, BaseApiResponse<PaymentSingleDto>>
    {
        private readonly IPaymentService _paymentService;

        public GetPaymentByIdHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> Handle(GetPaymentById request, CancellationToken cancellationToken)
        {
            return await _paymentService.GetOneAsync(request.Id, GetInclude());
        }

        private static Func<IQueryable<Payment>, IIncludableQueryable<Payment, object?>> GetInclude()
        {
            return x => x.Include(x => x.MembershipPayment)
                            .ThenInclude(x => x.Membership)
                                .ThenInclude(x => x.MembershipType)
                         .Include(x => x.MembershipPayment)
                            .ThenInclude(x => x.InstituteMember)
                                .ThenInclude(x => x.User);
        }
    }
}