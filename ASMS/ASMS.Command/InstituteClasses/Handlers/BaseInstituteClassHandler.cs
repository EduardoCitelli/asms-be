using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClasses;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services.Abstractions;
using MediatR;
using System.Linq.Expressions;

namespace ASMS.Command.InstituteClasses.Handlers
{
    /// <summary>
    /// Base class for Institute class create/update handler
    /// </summary>
    /// <typeparam name="TRequest">create/update request</typeparam>
    /// <typeparam name="TResponse">Base api response</typeparam>
    public abstract class BaseInstituteClassHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly TimeSpan _clientOffset;
        protected readonly IInstituteClassService _service;
        protected readonly IInstituteClassBlockService _blockService;

        protected BaseInstituteClassHandler(IInstituteClassService service,
                                            IInstituteClassBlockService blockService,
                                            IClientTimeOffsetService clientTimeOffsetService)
        {
            _service = service;
            _blockService = blockService;
            _clientOffset = clientTimeOffsetService.Offset;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await BasicExistentValidationAsync(request);
            await InstituteClassValidationsAsync(request);
            return await RunLogicAsync(request);
        }

        /// <summary>
        /// First Validation call to validate entities that are not institute class or institute class block
        /// </summary>
        /// <param name="request">Create/Update Request</param>
        protected abstract Task BasicExistentValidationAsync(TRequest request);

        /// <summary>
        /// Second Validation call to validate main entities (institute class and institute class block)
        /// </summary>
        /// <param name="request">Create/Update Request</param>
        protected abstract Task InstituteClassValidationsAsync(TRequest request);

        /// <summary>
        /// Logic for create/update institute class
        /// </summary>
        /// <param name="request">Create/Update Request</param>
        /// <returns>Expected response from request</returns>
        protected abstract Task<TResponse> RunLogicAsync(TRequest request);

        /// <summary>
        /// Call Validation to Check overlap on principal coach or room
        /// </summary>
        /// <typeparam name="T">type of Create/Update request</typeparam>
        /// <param name="request">Create/Update request</param>
        /// <param name="query">Existing query for validation</param>
        /// <param name="busyErrorMessage">Error message for range or just 1 date</param>
        /// <exception cref="BadRequestException">when the Coach or the room are busy for that range or date</exception>
        protected async Task ValidateOverlapCoachAndRoom<T>(T request,
                                                            Expression<Func<InstituteClassBlock, bool>> query,
                                                            string busyErrorMessage = "on that date range") where T : InstituteClassUpdateDto
        {
            query = query.And(NotCancelledClass());

            var exist = await _blockService.ValidateExistentAsync(query.And(CheckCoachOverlap(request.PrincipalCoachId)));

            if (exist)
                throw new BadRequestException($"The coach is busy {busyErrorMessage}");

            exist = await _blockService.ValidateExistentAsync(query.And(CheckRoomOverlap(request.RoomId)));

            if (exist)
                throw new BadRequestException($"The room is not available {busyErrorMessage}");
        }

        protected static Expression<Func<InstituteClassBlock, bool>> GetClassesFromRange(DateTime from, DateTime to)
        {
            return x => x.StartDateTime >= from && x.FinishDateTime <= to;
        }

        protected static Expression<Func<InstituteClassBlock, bool>> IncludeDayOfWeek(IEnumerable<DayOfWeek> days)
        {
            return x => days.Contains(x.DayOfWeek);
        }

        protected static Expression<Func<InstituteClassBlock, bool>> CheckOverlapDateTime(TimeSpan startHour, TimeSpan finishHour)
        {
            return CheckOverlapStartDateTime(startHour).Or(CheckOverlapFinishDateTime(finishHour));
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapStartDateTime(TimeSpan startHour)
        {
            return x => x.StartDateTime.TimeOfDay <= startHour && x.FinishDateTime.TimeOfDay > startHour;
        }

        private static Expression<Func<InstituteClassBlock, bool>> CheckOverlapFinishDateTime(TimeSpan finishHour)
        {
            return x => x.StartDateTime.TimeOfDay < finishHour && x.FinishDateTime.TimeOfDay >= finishHour;
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
    }
}
