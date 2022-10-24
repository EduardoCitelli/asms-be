namespace ASMS.Services.Abstractions
{
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoleService
    {
        Task<BaseApiResponse<IEnumerable<RoleListDto>>> GetAllAsync();
    }
}