using ASMS.CrossCutting.Utils;
using ASMS.DTOs.MembershipTypes;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.MembershipTypes.Requests
{
    public class GetAllMembershipTypes : PagedRequestDto, IRequest<BaseApiResponse<PagedList<MembershipTypeListDto>>>
    {
    }
}
