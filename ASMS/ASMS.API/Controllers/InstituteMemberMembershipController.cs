using ASMS.Command.InstituteMemberMemberships.Commands;
using ASMS.Command.InstituteMembers.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class InstituteMemberMembershipController : DefaultController
    {
        public InstituteMemberMembershipController(IMediator mediator, ILogger<InstituteMemberMembershipController> logger) 
            : base(mediator, logger)
        {
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.Member}")]
        public async Task<BaseApiResponse<long>> Create([FromBody] AssignMembershipCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
