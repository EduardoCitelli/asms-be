using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Users.Commands
{
    public class UnblockUserCommand : EntityByIdRequest<long>, IRequest<BaseApiResponse<bool>>
    {
        public UnblockUserCommand(long id) : base(id)
        {
        }
    }
}
