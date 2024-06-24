using ASMS.Command.Payments.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class PaymentController : DefaultController
    {
        public PaymentController(IMediator mediator, ILogger<PaymentController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<PaymentSingleDto>> Create(CreatePayment command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("force")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<PaymentSingleDto>> Create(CreateForcePayment command)
        {
            return await _mediator.Send(command);
        }
    }
}