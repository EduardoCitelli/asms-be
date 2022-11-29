using ASMS.Command.Activities.Commands;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Activities.Handlers
{
    public class ActivityUpdateHandler : IRequestHandler<ActivityUpdateCommand, BaseApiResponse<ActivitySingleDto>>
    {
        private readonly IActivityService _activityService;

        public ActivityUpdateHandler(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> Handle(ActivityUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _activityService.UpdateAsync(request);
        }
    }
}