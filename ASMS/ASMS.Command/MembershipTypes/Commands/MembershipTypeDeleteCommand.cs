using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.MembershipTypes.Commands
{
    public class MembershipTypeDeleteCommand : IRequest<BaseApiResponse<MembershipTypeSingleDto>>
    {
        public MembershipTypeDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}