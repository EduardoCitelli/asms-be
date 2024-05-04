namespace ASMS.Queries.Handlers
{
    using ASMS.CrossCutting.Utils;
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using ASMS.Queries.Requests;
    using ASMS.Services.Abstractions;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, BaseApiResponse<PagedList<RoleListDto>>>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<BaseApiResponse<PagedList<RoleListDto>>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _roleService.GetAllAsync(request.Page, request.Size);
        }
    }
}
