namespace ASMS.Queries.Plans.Handlers
{
    using ASMS.CrossCutting.Utils;
    using ASMS.DTOs.Plans;
    using ASMS.Infrastructure;
    using ASMS.Queries.Plans.Requests;
    using ASMS.Services;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllPlansHandler : IRequestHandler<GetAllPlans, BaseApiResponse<PagedList<PlanDto>>>
    {
        private readonly IPlanService _planService;

        public GetAllPlansHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<BaseApiResponse<PagedList<PlanDto>>> Handle(GetAllPlans request, CancellationToken cancellationToken)
        {
            return await _planService.GetListAsync(request.Page, request.Size);
        }
    }
}
