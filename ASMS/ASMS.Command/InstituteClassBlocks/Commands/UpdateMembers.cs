using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteClassBlocks.Commands
{
    public class UpdateMembers : EntityByIdRequest<long>, IRequest<BaseApiResponse<bool>>
    {
        public UpdateMembers(long id, IList<long> membersId) : base(id)
        {
            MembersId = membersId;
        }

        public IList<long> MembersId { get; set; }
    }
}