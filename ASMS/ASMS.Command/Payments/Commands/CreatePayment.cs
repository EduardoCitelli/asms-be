using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Payments.Commands
{
    public class CreatePayment : PaymentCreateDto, IRequest<BaseApiResponse<PaymentSingleDto>>
    {
    }
}