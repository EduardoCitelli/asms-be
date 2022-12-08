using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using ASMS.Queries.Activities.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Activities.Handlers
{
    public class GetActivityByIdHandler : IRequestHandler<GetActivityById, BaseApiResponse<ActivitySingleDto>>
    {
        private readonly IActivityService _activityService;

        public GetActivityByIdHandler(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> Handle(GetActivityById request, CancellationToken cancellationToken)
        {
            return await _activityService.GetOneAsync(request.Id);
        }
    }
}
