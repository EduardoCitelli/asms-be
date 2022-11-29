using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Memberships.Commands
{
    public class MembershipDeleteCommand : IRequest<BaseApiResponse<MembershipSingleDto>>
    {
        public MembershipDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}