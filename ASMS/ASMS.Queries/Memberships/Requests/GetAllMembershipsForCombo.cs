using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Memberships.Requests
{
    public class GetAllMembershipsForCombo : IRequest<BaseApiResponse<IEnumerable<MembershipComboDto>>>
    {
    }
}