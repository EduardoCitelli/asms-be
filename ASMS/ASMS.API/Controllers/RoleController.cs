﻿using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Roles;
using ASMS.Infrastructure;
using ASMS.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    public class RoleController : DefaultController
    {
        public RoleController(ILogger<RoleController> logger, IMediator mediator)
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<PagedList<RoleListDto>>> GetAll([FromQuery] GetAllRolesQueryRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
