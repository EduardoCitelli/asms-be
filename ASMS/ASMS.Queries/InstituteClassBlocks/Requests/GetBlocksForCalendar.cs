using ASMS.DTOs.InstituteClassBlocks;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteClassBlocks.Requests
{
    public class GetBlocksForCalendar : InstituteClassBlockCalendarRequestDto, IRequest<BaseApiResponse<IEnumerable<InstituteClassBlockCalendarDto>>>
    {        
    }
}
