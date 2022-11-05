namespace ASMS.Queries.Plans.Handlers
{
    using ASMS.DTOs.Plans;
    using ASMS.Infrastructure;
    using ASMS.Queries.Plans.Requests;
    using ASMS.Services;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOnePlanHandler : IRequestHandler<GetOnePlan, BaseApiResponse<PlanSingleDto>>
    {
        private readonly IPlanService _planService;

        public GetOnePlanHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<BaseApiResponse<PlanSingleDto>> Handle(GetOnePlan request, CancellationToken cancellationToken)
        {
            return await _planService.GetOneAsync(request.Id);
        }
    }
}