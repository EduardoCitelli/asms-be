using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.MembershipTypes.Commands
{
    public class MembershipTypeUpdateCommand : MembershipTypeUpdateDto, IRequest<BaseApiResponse<MembershipTypeSingleDto>>
    {
    }
}
