using ASMS.Command.Plans.Request;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using ASMS.Services;
using MediatR;

namespace ASMS.Command.Plans.Handlers
{
    public class PlanCreateHandler : IRequestHandler<PlanCreateCommand, BaseApiResponse<PlanSingleDto>>
    {
        private readonly IPlanService _planService;

        public PlanCreateHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<BaseApiResponse<PlanSingleDto>> Handle(PlanCreateCommand request, CancellationToken cancellationToken)
        {
            return await _planService.CreateAsync(request);
        }
    }
}
