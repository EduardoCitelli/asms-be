using ASMS.Command.InstituteClasses.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Utils;
using ASMS.CrossCutting.Utils.Models;
using ASMS.DTOs.InstituteClasses;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteClasses.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASMS.API.Controllers
{
    public class InstituteClassController : DefaultController
    {
        public InstituteClassController(IMediator mediator, ILogger<InstituteClassController> logger)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<BaseApiResponse<PagedList<InstituteClassListDto>>> Get([FromQuery] GetInstituteClasses request)
        {
            request.RootFilter = request.Filter.IsNullOrEmpty() ? null : JsonConvert.DeserializeObject<RootFilter>(request.Filter);
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<BaseApiResponse<InstituteClassSingleDto>> GetById([FromRoute] long id)
        {
            return await _mediator.Send(new GetInstituteClassById(id));
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<InstituteClassSingleDto>> Create(CreateInstituteClass command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{RoleTypes.SuperAdmin},{RoleTypes.Manager},{RoleTypes.StaffMember}")]
        public async Task<BaseApiResponse<InstituteClassSingleDto>> Update([FromRoute] long id, [FromBody] UpdateInstituteClass command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}