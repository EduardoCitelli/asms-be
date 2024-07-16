using ASMS.CrossCutting.Utils;
using ASMS.DTOs.InstituteClasses;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteClasses.Requests
{
    public class GetInstituteClasses : PagedFilterRequestDto, IRequest<BaseApiResponse<PagedList<InstituteClassListDto>>>
    {
    }
}
