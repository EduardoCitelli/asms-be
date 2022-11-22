using ASMS.Domain.Entities;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteService
    {
        Task<BaseApiResponse<InstituteSingleDto>> Create(InstituteCreateDto dto);

        Task<BaseApiResponse<InstituteSingleDto>> Update(InstituteUpdateDto dto);

        Task<BaseApiResponse<InstituteSingleDto>> Delete(long id);

        Task<bool> Any(Expression<Func<Institute, bool>> query,
                                    Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>>? include = null);
    }
}