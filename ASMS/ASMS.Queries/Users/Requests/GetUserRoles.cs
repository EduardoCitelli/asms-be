using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Users.Requests
{
    public class GetUserRoles : EntityByIdRequest<long>, IRequest<BaseApiResponse<IEnumerable<RoleTypeEnum>>>
    {
        public GetUserRoles(long id) : base(id)
        {
        }
    }
}
