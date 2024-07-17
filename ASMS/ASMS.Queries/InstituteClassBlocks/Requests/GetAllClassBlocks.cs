using ASMS.CrossCutting.Utils;
using ASMS.DTOs.InstituteClassBlocks;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteClassBlocks.Requests
{
    public class GetAllClassBlocks : PagedFilterRequestDto, IRequest<BaseApiResponse<PagedList<InstituteClassBlockListDto>>>
    {
    }
}
