using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Institutes;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Institutes.Requests
{
    public class GetAllInstitutes : PagedRequestDto, IRequest<BaseApiResponse<PagedList<InstituteListDto>>>
    {
    }
}
