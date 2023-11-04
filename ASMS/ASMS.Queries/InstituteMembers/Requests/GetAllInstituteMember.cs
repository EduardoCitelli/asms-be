using ASMS.CrossCutting.Utils;
using ASMS.DTOs.InstituteMembers;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteMembers.Requests
{
    public class GetAllInstituteMember : PagedRequestDto, IRequest<BaseApiResponse<PagedList<InstituteMemberListDto>>>
    {
    }
}
