using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClasses;
using ASMS.DTOs.Institutes;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteClassService
    {
        Task<BaseApiResponse<InstituteClassSingleDto>> CreateAsync(InstituteClassCreateDto dto,
                                                              Action<InstituteClass>? actionBeforeSave = null);

        Task<BaseApiResponse<PagedList<InstituteClassListDto>>> GetAllAsync(PagedFilterRequestDto request,
                                                                            Expression<Func<InstituteClass, bool>>? query = null,
                                                                            Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null);

        Task<BaseApiResponse<InstituteClassSingleDto>> GetOneAsync(long id, 
                                                              Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null);

        Task<BaseApiResponse<InstituteClassSingleDto>> UpdateAsync(InstituteClassUpdateDto request,
                                                              long key,
                                                              Action<InstituteClassUpdateDto, InstituteClass>? actionBeforeSave = null,
                                                              Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null);

        Task<(DateTime, ICollection<DayOfWeek>)> ValidateExistentAndGetFinishDateRangeWithDaysOfWeekFromRecurrentInstituteClassAsync(long id,
                                                                                                                                     Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null);
    }
}