using ASMS.Command.InstituteClass.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using System.Linq.Expressions;

namespace ASMS.Command.InstituteClass.Handlers
{
    public class CreateInstituteClassHandler : IRequestHandler<CreateInstituteClass, BaseApiResponse<bool>>
    {
        private readonly IInstituteClassService _service;
        private readonly IInstituteClassBlockService _blockService;
        private readonly IClientTimeOffsetService _clientTimeOffsetService;
        private readonly ICoachService _coachService;
        private readonly IRoomService _roomService;
        private readonly IActivityService _activityService;

        public CreateInstituteClassHandler(IInstituteClassService service,
                                           IInstituteClassBlockService blockService,
                                           IClientTimeOffsetService clientTimeOffsetService,
                                           ICoachService coachService,
                                           IRoomService roomService,
                                           IActivityService activityService)
        {
            _service = service;
            _blockService = blockService;
            _clientTimeOffsetService = clientTimeOffsetService;
            _coachService = coachService;
            _roomService = roomService;
            _activityService = activityService;
        }

        public async Task<BaseApiResponse<bool>> Handle(CreateInstituteClass request, CancellationToken cancellationToken)
        {
            request.ClientOffset = _clientTimeOffsetService.Offset;
            await BasicExistentValidations(request);

            if (!request.IsRecurrence)
                await ValidateNotRecurrenceClass(request);
            else
                await ValidateRecurrenceClass(request);

            var response = await _service.CreateAsync(request);

            return response;
        }

        private async Task BasicExistentValidations(CreateInstituteClass request)
        {
            await _roomService.ValidateExistingAsync(request.RoomId);
            await _activityService.ValidateExistingAsync(request.ActivityId);
            await _coachService.ValidateExistingAsync(request.PrincipalCoachId);

            if (request.AuxCoachId.HasValue)
                await _coachService.ValidateExistingAsync(request.AuxCoachId.Value);
        }

        private async Task ValidateNotRecurrenceClass(CreateInstituteClass request)
        {
            if (request.NotRecurrenceDate == null)
                throw new BadRequestException("Date for class not specified");

            var utcStartTime = request.StartTime.AddOffset(_clientTimeOffsetService.Offset);

            var notRecurrenceStartDateTime = request.NotRecurrenceDate.Value.Date.AddHours(utcStartTime.Hour)
                                                                                 .AddMinutes(utcStartTime.Minute);
            var notRecurrenceFinishDateTime = notRecurrenceStartDateTime.AddMinutes(request.MinutesDuration);

            var query = CheckOverlapDateTime(notRecurrenceStartDateTime, notRecurrenceFinishDateTime);

            await ValidateOverlapCoachAndRoom(request, query);
        }

        private async Task ValidateRecurrenceClass(CreateInstituteClass request)
        {
            if (!request.FromRange.HasValue || !request.ToRange.HasValue)
                throw new BadRequestException("You should specified range for recurrence class");

            if (request.DaysOfWeek == null || !request.DaysOfWeek.Any())
                throw new BadRequestException("You should specified days of week for recurrence class");

            var startHourUtc = request.StartTime.AddOffset(_clientTimeOffsetService.Offset).ToTimeSpan();

            var finishHourUtc = startHourUtc.Add(TimeSpan.FromMinutes(request.MinutesDuration));

            if (finishHourUtc.Days > 0)
                finishHourUtc = finishHourUtc.Subtract(TimeSpan.FromDays(1));


            var query = GetClassesFromRange(request.FromRange.Value, request.ToRange.Value)
                        .And(IncludeDayOfWeek(request.DaysOfWeek))
                        .And(CheckOverlapDateTime(startHourUtc, finishHourUtc));

            await ValidateOverlapCoachAndRoom(request, query);
        }

        private async Task ValidateOverlapCoachAndRoom(CreateInstituteClass request, Expression<Func<InstituteClassBlock, bool>> query)
        {
            query = query.And(NotCancelledClass());

            var busyErrorMessage = request.IsRecurrence ? "on that date range" : "for that date";

            var exist = await _blockService.ValidateExistentAsync(query.And(CheckCoachOverlap(request.PrincipalCoachId)));

            if (exist)
                throw new BadRequestException($"The coach is busy {busyErrorMessage}");

            exist = await _blockService.ValidateExistentAsync(query.And(CheckRoomOverlap(request.RoomId)));

            if (exist)
                throw new BadRequestException($"The room is not available {busyErrorMessage}");
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckCoachOverlap(long coachId)
        {
            return x => x.PrincipalCoachId == coachId;
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckRoomOverlap(long roomId)
        {
            return x => x.RoomId == roomId;
        }

        private static Expression<Func<InstituteClassBlock, bool>> NotCancelledClass()
        {
            return x => x.ClassStatus == ClassStatus.New;
        }

        private static Expression<Func<InstituteClassBlock, bool>> GetClassesFromRange(DateTime from, DateTime to)
        {
            return x => x.StartDateTime >= from && x.FinishDateTime <= to;
        }

        private static Expression<Func<InstituteClassBlock, bool>> IncludeDayOfWeek(IEnumerable<DayOfWeek> days)
        {
            return x => days.Contains(x.DayOfWeek);
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapDateTime(DateTime startDateTime, DateTime finishDateTime)
        {
            return CheckOverlapStartDateTime(startDateTime).Or(CheckOverlapFinishDateTime(finishDateTime));
        }
        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapDateTime(TimeSpan startHour, TimeSpan finishHour)
        {
            return CheckOverlapStartDateTime(startHour).Or(CheckOverlapFinishDateTime(finishHour));
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapStartDateTime(DateTime startDateTime)
        {
            return x => x.StartDateTime <= startDateTime && x.FinishDateTime > startDateTime;
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapStartDateTime(TimeSpan startHour)
        {
            return x => x.StartDateTime.TimeOfDay <= startHour && x.FinishDateTime.TimeOfDay > startHour;
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapFinishDateTime(DateTime finishDateTime)
        {
            return x => x.StartDateTime < finishDateTime && x.FinishDateTime >= finishDateTime;
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapFinishDateTime(TimeSpan finishHour)
        {
            return x => x.StartDateTime.TimeOfDay < finishHour && x.FinishDateTime.TimeOfDay >= finishHour;
        }
    }
}