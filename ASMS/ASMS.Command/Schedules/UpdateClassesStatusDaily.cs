using ASMS.Command.InstituteClassBlocks.Commands;
using ASMS.Services.Abstractions;
using Coravel.Invocable;
using MediatR;

namespace ASMS.Services.Schedules
{
    public class UpdateClassesStatusDaily : IInvocable
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;
        private readonly IMediator _mediator;

        public UpdateClassesStatusDaily(IInstituteClassBlockService instituteClassBlockService, 
                                        IMediator mediator)
        {
            _instituteClassBlockService = instituteClassBlockService;
            _mediator = mediator;
        }

        public async Task Invoke()
        {
            await _instituteClassBlockService.UpdateStatusFromActiveToFinished();

            var blocks = await _instituteClassBlockService.GetInactiveClassesToCancel();

            foreach (var block in blocks)
                await _mediator.Send(new CancelBlock(block.Id, true));
        }
    }
}