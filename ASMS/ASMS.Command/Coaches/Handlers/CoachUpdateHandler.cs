using ASMS.Command.Coaches.Commands;
using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Coaches.Handlers
{
    public class CoachUpdateHandler : IRequestHandler<CoachUpdateCommand, BaseApiResponse<CoachSingleDto>>
    {
        private readonly ICoachService _coachService;

        public CoachUpdateHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<BaseApiResponse<CoachSingleDto>> Handle(CoachUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _coachService.UpdateAsync(request);
        }
    }
}