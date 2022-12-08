using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Activities;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Activities.Requests
{
    public class GetAllActivities : PagedRequestDto, IRequest<BaseApiResponse<PagedList<ActivityListDto>>>
    {
    }
}
