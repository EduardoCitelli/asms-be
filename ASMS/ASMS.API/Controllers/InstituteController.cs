using MediatR;

namespace ASMS.API.Controllers
{
    public class InstituteController : DefaultController
    {
        public InstituteController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}
