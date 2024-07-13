using ASMS.Command.InstituteClasses.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Command.InstituteClasses.Handlers
{
    public class UpdateInstituteClassHandler : BaseInstituteClassHandler<UpdateInstituteClass, BaseApiResponse<bool>>
    {
        private readonly ICoachService _coachService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public UpdateInstituteClassHandler(IInstituteClassService service,
                                           IInstituteClassBlockService blockService,
                                           IClientTimeOffsetService clientTimeOffsetService,
                                           ICoachService coachService,
                                           IRoomService roomService,
                                           IMapper mapper)
            : base(service, blockService, clientTimeOffsetService)
        {
            _coachService = coachService;
            _roomService = roomService;
            _mapper = mapper;
        }

        protected override async Task BasicExistentValidationAsync(UpdateInstituteClass request)
        {
            request.ClientOffset = _clientOffset;
            await BasicExistentValidations(request);
        }

        protected override async Task InstituteClassValidationsAsync(UpdateInstituteClass request)
        {
            await ValidateRecurrenceClass(request);
        }

        protected override async Task<BaseApiResponse<bool>> RunLogicAsync(UpdateInstituteClass request)
        {
            return await _service.UpdateAsync(request, request.Id, MapPendingBlocks(), IncludeBlocksAndDaysOfWeek());
        }

        private async Task BasicExistentValidations(UpdateInstituteClass request)
        {
            await _roomService.ValidateExistingAsync(request.RoomId);
            await _coachService.ValidateExistingAsync(request.PrincipalCoachId);

            if (request.AuxCoachId.HasValue)
                await _coachService.ValidateExistingAsync(request.AuxCoachId.Value);
        }

        private async Task ValidateRecurrenceClass(UpdateInstituteClass request)
        {
            (var toRange, var daysOfWeek) = await _service.ValidateExistentAndGetFinishDateRangeWithDaysOfWeekFromRecurrentInstituteClassAsync(request.Id,
                                                                                                                                               IncludeDaysOfWeek());
            var startHourUtc = request.StartTime.AddOffset(_clientOffset)
                                                .ToTimeSpan();

            var finishHourUtc = startHourUtc.Add(TimeSpan.FromMinutes(request.MinutesDuration));

            if (finishHourUtc.Days > 0)
                finishHourUtc = finishHourUtc.Subtract(TimeSpan.FromDays(1));

            var query = GetClassesFromRange(DateTime.UtcNow, toRange)
                        .And(IncludeDayOfWeek(daysOfWeek))
                        .And(CheckOverlapDateTime(startHourUtc, finishHourUtc))
                        .And(DifferentInstituteClass(request.Id));

            await ValidateOverlapCoachAndRoom(request, query);
        }

        public static Expression<Func<InstituteClassBlock, bool>> DifferentInstituteClass(long instituteClass)
        {
            return x => x.InstituteClassId != instituteClass;
        }

        private Action<InstituteClassUpdateDto, InstituteClass> MapPendingBlocks()
        {
            return (dto, entity) =>
            {
                var blocks = entity.Blocks.Where(x => x.StartDateTime > DateTime.UtcNow && x.ClassStatus == ClassStatus.New);

                if (blocks.Any())
                    _mapper.Map(dto, blocks);
            };
        }

        private static Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>> IncludeDaysOfWeek()
        {
            return x => x.Include(x => x.DaysOfWeek);
        }

        private Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? IncludeBlocksAndDaysOfWeek()
        {
            return x => x.Include(x => x.Blocks)
                         .Include(x => x.DaysOfWeek);
        }
    }
}
