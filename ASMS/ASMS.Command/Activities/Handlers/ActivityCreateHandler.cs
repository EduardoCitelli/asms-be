using ASMS.Command.Activities.Commands;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Activities.Handlers
{
    public class ActivityCreateHandler : IRequestHandler<ActivityCreateCommand, BaseApiResponse<ActivitySingleDto>>
    {
        private readonly IActivityService _activityService;

        public ActivityCreateHandler(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> Handle(ActivityCreateCommand request, CancellationToken cancellationToken)
        {
            return await _activityService.CreateAsync(request);
        }
    }
}