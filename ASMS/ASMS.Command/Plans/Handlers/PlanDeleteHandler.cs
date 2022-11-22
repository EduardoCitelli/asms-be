using ASMS.Command.Plans.Commands;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using ASMS.Services;
using MediatR;

namespace ASMS.Command.Plans.Handlers
{
    public class PlanDeleteHandler : IRequestHandler<PlanDeleteCommand, BaseApiResponse<PlanSingleDto>>
    {
        private readonly IPlanService _planService;

        public PlanDeleteHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<BaseApiResponse<PlanSingleDto>> Handle(PlanDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _planService.DeleteAsync(request.PlanId);
        }
    }
}