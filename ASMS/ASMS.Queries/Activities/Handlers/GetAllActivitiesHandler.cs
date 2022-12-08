using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using ASMS.Queries.Activities.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Activities.Handlers
{
    public class GetAllActivitiesHandler : IRequestHandler<GetAllActivities, BaseApiResponse<PagedList<ActivityListDto>>>
    {
        private readonly IActivityService _activityService;

        public GetAllActivitiesHandler(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<BaseApiResponse<PagedList<ActivityListDto>>> Handle(GetAllActivities request, CancellationToken cancellationToken)
        {
            return await _activityService.GetListAsync(request.Page, request.Size);
        }
    }
}
