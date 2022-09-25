namespace ASMS.API.Controllers
{
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using ASMS.Queries.Requests.Roles;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;

        public RoleController(ILogger<RoleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<BaseApiResponse<IEnumerable<RoleListDto>>> GetAll()
        {
            return await _mediator.Send(new GetAllRolesQueryRequest());
        }
    }
}
