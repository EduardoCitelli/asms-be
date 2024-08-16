using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteClassBlocks.Commands
{
    public class RemoveMember : EntityByIdRequest<long>, IRequest<BaseApiResponse<bool>>
    {
        public RemoveMember(long id) : base(id)
        {
        }
    }
}
