using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.Coaches.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Coaches.Handlers
{
    public class GetCoachComboHandler : IRequestHandler<GetCoachCombo, BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
        private readonly ICoachService _coachService;

        public GetCoachComboHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> Handle(GetCoachCombo request, CancellationToken cancellationToken)
        {
            return await _coachService.GetComboAsync();
        }
    }
}