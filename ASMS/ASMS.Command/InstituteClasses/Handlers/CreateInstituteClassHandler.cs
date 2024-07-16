using ASMS.Command.InstituteClasses.Commands;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClasses;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using System.Linq.Expressions;

namespace ASMS.Command.InstituteClasses.Handlers
{
    public class CreateInstituteClassHandler : BaseInstituteClassHandler<CreateInstituteClass, BaseApiResponse<InstituteClassSingleDto>>
    {
        private readonly ICoachService _coachService;
        private readonly IRoomService _roomService;
        private readonly IActivityService _activityService;

        public CreateInstituteClassHandler(IInstituteClassService service,
                                           IInstituteClassBlockService blockService,
                                           IClientTimeOffsetService clientTimeOffsetService,
                                           ICoachService coachService,
                                           IRoomService roomService,
                                           IActivityService activityService)
            : base(service, blockService, clientTimeOffsetService)
        {
            _coachService = coachService;
            _roomService = roomService;
            _activityService = activityService;
        }

        protected override async Task BasicExistentValidationAsync(CreateInstituteClass request)
        {
            request.ClientOffset = _clientOffset;
            await BasicExistentValidations(request);
        }

        protected override async Task InstituteClassValidationsAsync(CreateInstituteClass request)
        {
            if (!request.IsRecurrence)
                await ValidateNotRecurrenceClass(request);
            else
                await ValidateRecurrenceClass(request);
        }

        protected override async Task<BaseApiResponse<InstituteClassSingleDto>> RunLogicAsync(CreateInstituteClass request)
        {
            return await _service.CreateAsync(request);
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

            var utcStartTime = request.StartTime.AddOffset(_clientOffset);

            var notRecurrenceStartDateTime = request.NotRecurrenceDate.Value.Date.AddHours(utcStartTime.Hour)
                                                                                 .AddMinutes(utcStartTime.Minute);

            var notRecurrenceFinishDateTime = notRecurrenceStartDateTime.AddMinutes(request.MinutesDuration);

            var query = CheckOverlapDateTime(notRecurrenceStartDateTime, notRecurrenceFinishDateTime);

            await ValidateOverlapCoachAndRoom(request, query, "for that date");
        }

        private async Task ValidateRecurrenceClass(CreateInstituteClass request)
        {
            if (!request.FromRange.HasValue || !request.ToRange.HasValue)
                throw new BadRequestException("You should specified range for recurrence class");

            if (request.DaysOfWeek == null || !request.DaysOfWeek.Any())
                throw new BadRequestException("You should specified days of week for recurrence class");

            var startHourUtc = request.StartTime.AddOffset(_clientOffset)
                                                .ToTimeSpan();

            var finishHourUtc = startHourUtc.Add(TimeSpan.FromMinutes(request.MinutesDuration));

            if (finishHourUtc.Days > 0)
                finishHourUtc = finishHourUtc.Subtract(TimeSpan.FromDays(1));


            var query = GetClassesFromRange(request.FromRange.Value, request.ToRange.Value)
                        .And(IncludeDayOfWeek(request.DaysOfWeek))
                        .And(CheckOverlapDateTime(startHourUtc, finishHourUtc));

            await ValidateOverlapCoachAndRoom(request, query);
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapDateTime(DateTime startDateTime, DateTime finishDateTime)
        {
            return CheckOverlapStartDateTime(startDateTime).Or(CheckOverlapFinishDateTime(finishDateTime));
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapStartDateTime(DateTime startDateTime)
        {
            return x => x.StartDateTime <= startDateTime && x.FinishDateTime > startDateTime;
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapFinishDateTime(DateTime finishDateTime)
        {
            return x => x.StartDateTime < finishDateTime && x.FinishDateTime >= finishDateTime;
        }
    }
}