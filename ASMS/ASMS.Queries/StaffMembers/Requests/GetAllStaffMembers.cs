using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Shared;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.StaffMembers.Requests
{
    public class GetAllStaffMembers : PagedRequestDto, IRequest<BaseApiResponse<PagedList<StaffMemberListDto>>>
    {
    }
}
