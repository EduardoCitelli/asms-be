using ASMS.DTOs.Payments;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Payments.Requests
{
    public class GetPaymentById : EntityByIdRequest<long>, IRequest<BaseApiResponse<PaymentSingleDto>>
    {
        public GetPaymentById(long id)
            : base(id)
        {
        }
    }
}