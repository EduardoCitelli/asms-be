namespace ASMS.Services
{
    using ASMS.CrossCutting.Enums;
    using ASMS.CrossCutting.Services.Abstractions;
    using ASMS.CrossCutting.Utils;
    using ASMS.Domain.Entities;
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using ASMS.Persistence.Abstractions;
    using ASMS.Services.Abstractions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore.Query;
    using System.Threading.Tasks;

    public class RoleService : ServiceBase<Role, RoleTypeEnum, RoleDto, RoleListDto>, IRoleService
    {
        public RoleService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Role), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<RoleListDto>>> GetAllAsync(int pageNumber = 1,
                                                                               int pageSize = 10,
                                                                               Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, null, include);
        }
    }
}
