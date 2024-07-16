using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClasses;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class InstituteClassService : ServiceBase<InstituteClass, long, InstituteClassSingleDto, InstituteClassListDto>, IInstituteClassService
    {
        public InstituteClassService(IMapper mapper, IUnitOfWork uow, IInstituteIdService instituteIdService)
            : base(uow, nameof(InstituteClass), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<InstituteClassSingleDto>> CreateAsync(InstituteClassCreateDto dto,
                                                                           Action<InstituteClass>? actionBeforeSave = null)
        {
            return await CreateBaseAsync(dto, actionBeforeSave);
        }

        public async Task<BaseApiResponse<InstituteClassSingleDto>> UpdateAsync(InstituteClassUpdateDto request,
                                                                                long key,
                                                                                Action<InstituteClassUpdateDto, InstituteClass>? actionBeforeSave = null,
                                                                                Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null)
        {
            return await UpdateBaseAsync(request, key, actionBeforeSave, include);
        }

        public async Task<BaseApiResponse<PagedList<InstituteClassListDto>>> GetAllAsync(PagedFilterRequestDto request,
                                                                                         Expression<Func<InstituteClass, bool>>? query = null,
                                                                                         Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(request, query, include);
        }

        public async Task<BaseApiResponse<InstituteClassSingleDto>> GetOneAsync(long id,
                                                                                Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null)
        {
            return await GetOneDtoBaseAsync(id, include);
        }

        public async Task<(DateTime, ICollection<DayOfWeek>)> ValidateExistentAndGetFinishDateRangeWithDaysOfWeekFromRecurrentInstituteClassAsync(long id,
                                                                                                                                                  Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null)
        {
            var existentEntity = await TryGetExistentEntityBaseAsync(id, include);

            if (existentEntity.ToRange == null || existentEntity.DaysOfWeek.IsNullOrEmpty())
                throw new BadRequestException("You're trying to get a not recurrence class");

            return (existentEntity.ToRange.Value, existentEntity.DaysOfWeek!.Select(x => x.DayOfWeek).ToList());
        }
    }
}