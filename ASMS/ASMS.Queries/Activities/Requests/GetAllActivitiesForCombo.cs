using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Activities.Requests
{
    public class GetAllActivitiesForCombo : IRequest<BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
    }
}
