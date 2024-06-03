using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.Plans.Requests;
using ASMS.Services;
using MediatR;

namespace ASMS.Queries.Plans.Handlers
{
    public class GetPlansForComboHandler : IRequestHandler<GetPlansForCombo, BaseApiResponse<IEnumerable<ComboDto<int>>>>
    {
        private readonly IPlanService _service;

        public GetPlansForComboHandler(IPlanService service)
        {
            _service = service;
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<int>>>> Handle(GetPlansForCombo request, CancellationToken cancellationToken)
        {
            return await _service.GetForComboAsync();
        }
    }
}