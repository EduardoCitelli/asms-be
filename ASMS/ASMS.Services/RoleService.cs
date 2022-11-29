namespace ASMS.Services
{
    using ASMS.CrossCutting.Enums;
    using ASMS.CrossCutting.Services.Abstractions;
    using ASMS.Domain.Entities;
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using ASMS.Persistence.Abstractions;
    using ASMS.Services.Abstractions;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RoleService : ServiceBase<Role, RoleTypeEnum, RoleDto, RoleListDto>, IRoleService
    {
        public RoleService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Role), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<IEnumerable<RoleListDto>>> GetAllAsync() => await GetAllDtosBaseAsync();
    }
}
