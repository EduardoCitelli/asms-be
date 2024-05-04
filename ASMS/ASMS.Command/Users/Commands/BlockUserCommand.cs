using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Users.Commands
{
    public class BlockUserCommand : EntityByIdRequest<long>, IRequest<BaseApiResponse<bool>>
    {
        public BlockUserCommand(long id) : base(id)
        {
        }
    }
}
