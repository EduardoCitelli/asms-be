using ASMS.Command.InstituteClasses.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class InstituteClassController : DefaultController
    {
        public InstituteClassController(IMediator mediator, ILogger<InstituteClassController> logger)
            : base(mediator, logger)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<bool>> Create(CreateInstituteClass command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<bool>> Update([FromRoute] long id, [FromBody] UpdateInstituteClass command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}