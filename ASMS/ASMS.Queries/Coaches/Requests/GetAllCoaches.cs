namespace ASMS.Queries.Coaches.Requests
{
    using ASMS.CrossCutting.Utils;
    using ASMS.DTOs.Coaches;
    using ASMS.DTOs.Shared;
    using ASMS.Infrastructure;
    using MediatR;

    public class GetAllCoaches : PagedRequestDto, IRequest<BaseApiResponse<PagedList<CoachListDto>>>
    {
    }
}
