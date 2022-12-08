using ASMS.DTOs.Memberships;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Memberships.Requests
{
    public class GetMembershipById : EntityByIdRequest<long>, IRequest<BaseApiResponse<MembershipSingleDto>>
    {
    }
}
