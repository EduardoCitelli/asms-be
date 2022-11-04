using ASMS.Command.Plans.Request;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using ASMS.Services;
using MediatR;

namespace ASMS.Command.Plans.Handlers
{
    public class PlanUpdateHandler : IRequestHandler<PlanUpdateCommand, BaseApiResponse<PlanSingleDto>>
    {
        private readonly IPlanService _planService;

        public PlanUpdateHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<BaseApiResponse<PlanSingleDto>> Handle(PlanUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _planService.UpdateAsync(request);
        }
    }
}