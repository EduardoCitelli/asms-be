using ASMS.Command.InstitutePlan.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class InstitutePlanController : DefaultController
    {
        public InstitutePlanController(IMediator mediator, ILogger<InstitutePlanController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<bool>> Create([FromBody] SetNewInstitutePlanCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
