namespace ASMS.Queries.Coaches.Handlers
{
    using ASMS.CrossCutting.Utils;
    using ASMS.Domain.Entities;
    using ASMS.DTOs.Coaches;
    using ASMS.Infrastructure;
    using ASMS.Queries.Coaches.Requests;
    using ASMS.Services.Abstractions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllCoachesHandler : IRequestHandler<GetAllCoaches, BaseApiResponse<PagedList<CoachListDto>>>
    {
        private readonly ICoachService _coachService;

        public GetAllCoachesHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<BaseApiResponse<PagedList<CoachListDto>>> Handle(GetAllCoaches request, CancellationToken cancellationToken)
        {
            return await _coachService.GetListAsync(request.Page,
                                                    request.Size,
                                                    null,
                                                    IncludeUser());
        }

        private static Func<IQueryable<Coach>, IIncludableQueryable<Coach, object>> IncludeUser() => x => x.Include(x => x.User);
    }
}