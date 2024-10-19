using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using ASMS.Queries.Payments.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Payments.Handlers
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPayments, BaseApiResponse<PagedList<PaymentListDto>>>
    {
        private IPaymentService _paymentService;

        public GetAllPaymentsHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<BaseApiResponse<PagedList<PaymentListDto>>> Handle(GetAllPayments request, CancellationToken cancellationToken)
        {
            return await _paymentService.GetListAsync(request, orderBy: x => x.EmittedDate, isDesc: true);
        }
    }
}