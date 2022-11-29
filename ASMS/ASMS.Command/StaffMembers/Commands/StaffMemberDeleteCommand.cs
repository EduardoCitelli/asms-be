using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.StaffMembers.Commands
{
    public class StaffMemberDeleteCommand : IRequest<BaseApiResponse<StaffMemberSingleDto>>
    {
        public StaffMemberDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}