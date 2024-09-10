using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteService
    {
        Task<BaseApiResponse<InstituteSingleDto>> GetOneAsync(long id);

        Task<BaseApiResponse<InstituteSingleDto>> Create(InstituteCreateDto dto);

        Task<BaseApiResponse<InstituteSingleDto>> Update(InstituteUpdateDto dto);

        Task<BaseApiResponse<InstituteSingleDto>> Delete(long id);

        Task<bool> Any(Expression<Func<Institute, bool>> query,
                       Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>>? include = null);

        Task<BaseApiResponse<PagedList<InstituteListDto>>> GetListAsync(int pageNumber = 1, 
                                                                        int pageSize = 10, 
                                                                        Expression<Func<Institute, bool>>? query = null, 
                                                                        Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>>? include = null);

        Task<BaseApiResponse<bool>> SetDisableInstitute(long instituteId, Action<Institute> businessLogic);

        Task<Institute> GetEntityByIdAsync(long id, Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>>? include = null);

        Task ValidateCanAddMembers();
    }
}