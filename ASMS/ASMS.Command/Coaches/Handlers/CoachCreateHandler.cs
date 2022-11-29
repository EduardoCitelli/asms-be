using ASMS.Command.Coaches.Commands;
using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Coaches.Handlers
{
    public class CoachCreateHandler : IRequestHandler<CoachCreateCommand, BaseApiResponse<CoachSingleDto>>
    {
        private readonly ICoachService _coachService;

        public CoachCreateHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<BaseApiResponse<CoachSingleDto>> Handle(CoachCreateCommand request, CancellationToken cancellationToken)
        {
            return await _coachService.CreateAsync(request);
        }
    }
}