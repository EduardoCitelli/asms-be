using ASMS.Command.Institutes.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Queries.Institutes.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class InstituteController : DefaultController
    {
        private readonly IUserInfoService _userInfoService;

        public InstituteController(IMediator mediator, IUserInfoService userInfoService)
            : base(mediator)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        [Route("mine")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<InstituteSingleDto>> GetMyInstitute()
        {
            var request = new GetInstituteById(_userInfoService.Value!.Id);
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<InstituteSingleDto>> Create([FromBody] InstituteCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{instituteId}")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<InstituteSingleDto>> Update([FromRoute] long instituteId, [FromBody] InstituteUpdateCommand command)
        {
            command.Id = instituteId;
            return await _mediator.Send(command);
        }

        [HttpPut]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager}")]
        public async Task<BaseApiResponse<InstituteSingleDto>> UpdateMyInstitute([FromBody] InstituteUpdateCommand command)
        {
            command.Id = _userInfoService.Value!.Id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{instituteId}")]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<InstituteSingleDto>> Delete([FromRoute] long instituteId)
        {
            return await _mediator.Send(new InstituteDeleteCommand(instituteId));
        }
    }
}