using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Coaches.Requests
{
    public class GetCoachCombo : IRequest<BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
    }
}
