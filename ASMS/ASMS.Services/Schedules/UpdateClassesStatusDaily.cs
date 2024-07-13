using ASMS.Services.Abstractions;
using Coravel.Invocable;

namespace ASMS.Services.Schedules
{
    public class UpdateClassesStatusDaily : IInvocable
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;

        public UpdateClassesStatusDaily(IInstituteClassBlockService instituteClassBlockService)
        {
            _instituteClassBlockService = instituteClassBlockService;
        }

        public async Task Invoke()
        {
            await _instituteClassBlockService.UpdateStatusFromNewToFinished();
        }
    }
}
