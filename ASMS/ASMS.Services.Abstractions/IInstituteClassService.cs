using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteClassService
    {
        Task<BaseApiResponse<bool>> CreateAsync(InstituteClassCreateDto dto, Action<InstituteClass>? actionBeforeSave = null);
        Task<BaseApiResponse<bool>> UpdateAsync(InstituteClassUpdateDto request, long key, Action<InstituteClassUpdateDto, InstituteClass>? actionBeforeSave = null, Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null);
        Task<(DateTime, ICollection<DayOfWeek>)> ValidateExistentAndGetFinishDateRangeWithDaysOfWeekFromRecurrentInstituteClassAsync(long id, Func<IQueryable<InstituteClass>, IIncludableQueryable<InstituteClass, object?>>? include = null);
    }
}