using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Payments;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Payments.Requests
{
    public class GetAllPayments : PagedFilterRequestDto, IRequest<BaseApiResponse<PagedList<PaymentListDto>>>
    {
    }
}