using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Shared;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Users.Requests
{
    public class GetAllUsers : PagedRequestDto, IRequest<BaseApiResponse<PagedList<UserListDto>>>
    {
    }
}
