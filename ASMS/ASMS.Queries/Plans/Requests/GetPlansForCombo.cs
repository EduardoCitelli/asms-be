using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Plans.Requests
{
    public class GetPlansForCombo : IRequest<BaseApiResponse<IEnumerable<ComboDto<int>>>>
    {
    }
}
