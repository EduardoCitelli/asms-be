using ASMS.CrossCutting.Enums;
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
        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger, IMediator mediator)
            : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = RoleTypes.SuperAdmin)]
        public async Task<BaseApiResponse<IEnumerable<RoleListDto>>> GetAll()
        {
            return await _mediator.Send(new GetAllRolesQueryRequest());
        }
    }
}
