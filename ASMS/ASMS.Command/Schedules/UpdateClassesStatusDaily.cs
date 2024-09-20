using ASMS.Command.InstituteClassBlocks.Commands;
using ASMS.Services.Abstractions;
using Coravel.Invocable;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ASMS.Services.Schedules
{
    public class UpdateClassesStatusDaily : IInvocable
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;
        private readonly IMediator _mediator;
        private readonly ILogger<UpdateClassesStatusDaily> _logger;

        public UpdateClassesStatusDaily(IInstituteClassBlockService instituteClassBlockService, 
                                        IMediator mediator,
                                        ILogger<UpdateClassesStatusDaily> logger)
        {
            _instituteClassBlockService = instituteClassBlockService;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Invoke()
        {
            _logger.LogInformation("Starting schedule service");

            await _instituteClassBlockService.UpdateStatusFromActiveToFinished();

            var blocks = await _instituteClassBlockService.GetInactiveClassesToCancel();

            _logger.LogInformation("About to cancel these blocks {blocks}", blocks);

            foreach (var block in blocks)
                await _mediator.Send(new CancelBlock(block.Id, true));
        }
    }
}