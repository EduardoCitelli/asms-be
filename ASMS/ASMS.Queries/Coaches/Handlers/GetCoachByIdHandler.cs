namespace ASMS.Queries.Coaches.Handlers
{
    using ASMS.DTOs.Coaches;
    using ASMS.Infrastructure;
    using ASMS.Queries.Coaches.Requests;
    using ASMS.Services.Abstractions;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCoachByIdHandler : IRequestHandler<GetCoachById, BaseApiResponse<CoachSingleDto>>
    {
        private readonly ICoachService _coachService;

        public GetCoachByIdHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<BaseApiResponse<CoachSingleDto>> Handle(GetCoachById request, CancellationToken cancellationToken)
        {
            return await _coachService.GetOneAsync(request.Id);
        }
    }
}
