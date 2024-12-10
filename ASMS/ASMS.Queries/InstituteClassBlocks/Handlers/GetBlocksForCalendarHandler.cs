using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Services.Abstractions;
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
        private readonly IInstituteMemberService _instituteMemberService;
        private readonly IUserInfoService _userInfoService;

        private readonly RoleTypeEnum[] _staffUsers = { RoleTypeEnum.StaffMember, RoleTypeEnum.SuperAdmin, RoleTypeEnum.Manager };

        public GetBlocksForCalendarHandler(IInstituteClassBlockService instituteClassBlockService,
                                           IInstituteMemberService instituteMemberService,
                                           IUserInfoService userInfoService)
        {
            _instituteClassBlockService = instituteClassBlockService;
            _userInfoService = userInfoService;
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<IEnumerable<InstituteClassBlockCalendarDto>>> Handle(GetBlocksForCalendar request, CancellationToken cancellationToken)
        {
            var query = GenerateQuery(request);

            var dtos = await _instituteClassBlockService.GetListDtoAsync<InstituteClassBlockCalendarDto>(query, GetInclude(), GetOrderBy());

            var hasStaffPermissions = _userInfoService.Value!.Roles.Any(x => _staffUsers.Contains(x));

            if (hasStaffPermissions)
                return new BaseApiResponse<IEnumerable<InstituteClassBlockCalendarDto>>(dtos);

            var instituteMember = await _instituteMemberService.GetEntityByUserId(_userInfoService.Value!.Id);

            foreach(var dto in dtos)
            {
                dto.IsAlreadyInClass = dto.MemberIds.Contains(instituteMember.Id);
                dto.MemberIds = new List<long>();
            }

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