namespace ASMS.Queries.Handlers
{
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using ASMS.Queries.Requests.Roles;
    using ASMS.Services;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, BaseApiResponse<IEnumerable<RoleListDto>>>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<BaseApiResponse<IEnumerable<RoleListDto>>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken) 
            => await _roleService.GetAllAsync();
    }
}
