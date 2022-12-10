using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.MembershipTypes.Requests
{
    public class GetAllMembershipTypesForCombo : IRequest<BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
    }
}
