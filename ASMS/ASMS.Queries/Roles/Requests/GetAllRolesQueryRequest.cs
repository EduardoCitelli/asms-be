namespace ASMS.Queries.Requests
{
    using ASMS.DTOs.Roles;
    using ASMS.DTOs.Shared;
    using ASMS.Infrastructure;
    using MediatR;

    public class GetAllRolesQueryRequest : PagedRequestDto, IRequest<BaseApiResponse<IEnumerable<RoleListDto>>>
    {
    }
}
