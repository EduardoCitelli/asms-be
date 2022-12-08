using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Memberships;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Memberships.Requests
{
    public class GetAllMemberships : PagedRequestDto, IRequest<BaseApiResponse<PagedList<MembershipListDto>>>
    {
    }
}
