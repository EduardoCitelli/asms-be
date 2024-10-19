using ASMS.Command.Payments.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Utils;
using ASMS.CrossCutting.Utils.Models;
using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using ASMS.Queries.Payments.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASMS.API.Controllers
{
    public class PaymentController : DefaultController
    {
        public PaymentController(IMediator mediator, ILogger<PaymentController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<BaseApiResponse<PagedList<PaymentListDto>>> GetAll([FromQuery] GetAllPayments request)
        {
            request.RootFilter = request.Filter.IsNullOrEmpty() ? null : JsonConvert.DeserializeObject<RootFilter>(request.Filter);
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<BaseApiResponse<PaymentSingleDto>> GetById([FromRoute] long id)
        {
            return await _mediator.Send(new GetPaymentById(id));
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