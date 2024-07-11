using ASMS.Command.InstituteClass.Commands;
using ASMS.Infrastructure;
using MediatR;
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
        public async Task<BaseApiResponse<bool>> Create(CreateInstituteClass command)
        {
            return await _mediator.Send(command);
        }
    }
}
