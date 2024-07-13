using ASMS.CrossCutting.Extensions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services
{
    public class InstituteClassService : IInstituteClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IRepository<InstituteClass, long> _repository;

        public InstituteClassService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _repository = _uow.GetRepository<InstituteClass, long>();
        }

        public async Task<BaseApiResponse<bool>> CreateAsync(InstituteClassCreateDto dto,
                                                             Action<InstituteClass>? actionBeforeSave = null)
        {
            var newEntity = _mapper.Map<InstituteClass>(dto);

            actionBeforeSave?.Invoke(newEntity);

            await _repository.AddAsync(newEntity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<bool>(success);

            var message = $"Problem while saving Institute class changes";

            throw new InternalErrorException(message);
        }

        public async Task<BaseApiResponse<bool>> UpdateAsync(InstituteClassUpdateDto request,
                                                             long key,
                                                             Action<InstituteClassUpdateDto, InstituteClass>? actionBeforeSave = null,
                                                             Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null)
        {
            var entity = await TryGetExistentEntityBaseAsync(key, include);

            actionBeforeSave?.Invoke(request, entity);

            entity = _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<bool>(true);

            var message = $"Problem while saving Institute class changes";

            throw new InternalErrorException(message);
        }

        public async Task<(DateTime, ICollection<DayOfWeek>)> ValidateExistentAndGetFinishDateRangeWithDaysOfWeekFromRecurrentInstituteClassAsync(long id,
                                                                                                                                                  Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null)
        {
            var existentEntity = await TryGetExistentEntityBaseAsync(id, include);

            if (existentEntity.ToRange == null || existentEntity.DaysOfWeek.IsNullOrEmpty())
                throw new BadRequestException("You're trying to get a not recurrence class");

            return (existentEntity.ToRange.Value, existentEntity.DaysOfWeek!.Select(x => x.DayOfWeek).ToList());
        }

        private async Task<InstituteClass> TryGetExistentEntityBaseAsync(long key,
                                                                         Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null)
        {
            var existentEntity = await _repository.GetByIdAsync(key, include);

            if (existentEntity == null)
            {
                var message = $"Entity: Institute class with key: {key} does not exist";
                throw new NotFoundException(message);
            }

            return existentEntity;
        }
    }
}