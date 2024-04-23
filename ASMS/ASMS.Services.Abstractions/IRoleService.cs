namespace ASMS.Services.Abstractions
{
    using ASMS.CrossCutting.Utils;
    using ASMS.Domain.Entities;
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using Microsoft.EntityFrameworkCore.Query;
    using System.Threading.Tasks;

    public interface IRoleService
    {
        Task<BaseApiResponse<PagedList<RoleListDto>>> GetAllAsync(int pageNumber = 1,
                                                                  int pageSize = 10,
                                                                  Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null);
    }
}