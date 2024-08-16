using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteClassBlocks.Commands
{
    public class AddMember : EntityByIdRequest<long>, IRequest<BaseApiResponse<bool>>
    {
        public AddMember(long id) : base(id)
        {
        }
    }
}
