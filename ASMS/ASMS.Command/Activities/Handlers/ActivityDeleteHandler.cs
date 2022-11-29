using ASMS.Command.Activities.Commands;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Activities.Handlers
{
    public class ActivityDeleteHandler : IRequestHandler<ActivityDeleteCommand, BaseApiResponse<ActivitySingleDto>>
    {
        private readonly IActivityService _activityService;

        public ActivityDeleteHandler(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> Handle(ActivityDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _activityService.DeleteAsync(request.Id);
        }
    }
}