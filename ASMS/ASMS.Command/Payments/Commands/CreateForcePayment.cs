using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Payments.Commands
{
    public class CreateForcePayment : PaymentCreateDto, IRequest<BaseApiResponse<PaymentSingleDto>>
    {
    }
}
