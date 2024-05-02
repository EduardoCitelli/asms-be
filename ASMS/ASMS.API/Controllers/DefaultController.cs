using ASMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidateModelAttribute))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class DefaultController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger<DefaultController> _logger;

        public DefaultController(IMediator mediator, ILogger<DefaultController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
    }
}
