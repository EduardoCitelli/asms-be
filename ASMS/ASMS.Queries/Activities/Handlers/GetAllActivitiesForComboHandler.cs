using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.Activities.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Activities.Handlers
{
    public class GetAllActivitiesForComboHandler : IRequestHandler<GetAllActivitiesForCombo, BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
        private readonly IActivityService _service;

        public GetAllActivitiesForComboHandler(IActivityService service)
        {
            _service = service;
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> Handle(GetAllActivitiesForCombo request, CancellationToken cancellationToken)
        {
            return await _service.GetForComboAsync();
        }
    }
}
