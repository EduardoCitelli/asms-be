namespace ASMS.Queries.Coaches.Requests
{
    using ASMS.DTOs.Coaches;
    using ASMS.DTOs.Shared;
    using ASMS.Infrastructure;
    using MediatR;

    public class GetCoachById : EntityByIdRequest<long>, IRequest<BaseApiResponse<CoachSingleDto>>
    {
    }
}
