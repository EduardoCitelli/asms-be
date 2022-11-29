using ASMS.Command.Coaches.Commands;
using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Coaches.Handlers
{
    public class CoachDeleteHandler : IRequestHandler<CoachDeleteCommand, BaseApiResponse<CoachSingleDto>>
    {
        private readonly ICoachService _coachService;

        public CoachDeleteHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<BaseApiResponse<CoachSingleDto>> Handle(CoachDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _coachService.DeleteAsync(request.Id);
        }
    }
}