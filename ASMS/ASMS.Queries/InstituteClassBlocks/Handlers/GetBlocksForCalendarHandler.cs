using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClassBlocks;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteClassBlocks.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Queries.InstituteClassBlocks.Handlers
{
    public class GetBlocksForCalendarHandler : IRequestHandler<GetBlocksForCalendar, BaseApiResponse<IEnumerable<InstituteClassBlockCalendarDto>>>
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;

        public GetBlocksForCalendarHandler(IInstituteClassBlockService instituteClassBlockService)
        {
            _instituteClassBlockService = instituteClassBlockService;
        }

        public async Task<BaseApiResponse<IEnumerable<InstituteClassBlockCalendarDto>>> Handle(GetBlocksForCalendar request, CancellationToken cancellationToken)
        {
            var query = GenerateQuery(request);

            var dtos = await _instituteClassBlockService.GetListDtoAsync<InstituteClassBlockCalendarDto>(query, GetInclude(), GetOrderBy());

            return new BaseApiResponse<IEnumerable<InstituteClassBlockCalendarDto>>(dtos);
        }

        private static Expression<Func<InstituteClassBlock, bool>> GenerateQuery(GetBlocksForCalendar request)
        {
            return GetByRoomId(request.RoomId)
                   .And(GetFromDate(request.From))
                   .And(GetToDate(request.To))
                   .And(GetNotCancelledClasses());
        }

        private static Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>> GetInclude()
        {
            return x => x.Include(x => x.Header)
                         .Include(x => x.PrincipalCoach);
        }

        private static Expression<Func<InstituteClassBlock, object>> GetOrderBy() => x => x.StartDateTime;

        private static Expression<Func<InstituteClassBlock, bool>> GetToDate(DateTime to) => x => x.StartDateTime <= to;

        private static Expression<Func<InstituteClassBlock, bool>> GetFromDate(DateTime from) => x => x.StartDateTime >= from;

        private static Expression<Func<InstituteClassBlock, bool>> GetByRoomId(long roomId) => x => x.RoomId == roomId;

        private static Expression<Func<InstituteClassBlock, bool>> GetNotCancelledClasses() => x => x.ClassStatus == ClassStatus.Active || x.ClassStatus == ClassStatus.Pending;
    }
}