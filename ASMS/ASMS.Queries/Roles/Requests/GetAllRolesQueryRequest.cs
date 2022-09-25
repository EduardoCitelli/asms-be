namespace ASMS.Queries.Requests
{
    using ASMS.DTOs.Roles;
    using ASMS.Infrastructure;
    using MediatR;

    public class GetAllRolesQueryRequest : IRequest<BaseApiResponse<IEnumerable<RoleListDto>>>
    {
    }
}
