using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Plans.Requests
{
    public class GetAllPlans : IRequest<BaseApiResponse<PagedList<PlanDto>>>
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;
    }
}