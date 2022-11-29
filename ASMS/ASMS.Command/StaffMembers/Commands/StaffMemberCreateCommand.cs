using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.StaffMembers.Commands
{
    public class StaffMemberCreateCommand : StaffMemberCreateDto, IRequest<BaseApiResponse<StaffMemberSingleDto>>
    {
    }
}
