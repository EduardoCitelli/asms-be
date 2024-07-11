using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteClassService
    {
        Task<BaseApiResponse<bool>> CreateAsync(InstituteClassCreateDto dto, Action<InstituteClass>? actionBeforeSave = null);
    }
}