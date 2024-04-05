using ASMS.DTOs.Shared;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Users.Requests
{
    public class GetUserById : EntityByIdRequest<long>, IRequest<BaseApiResponse<UserBasicDto>>
    {
        public GetUserById(long id) : base(id)
        {
        }
    }
}