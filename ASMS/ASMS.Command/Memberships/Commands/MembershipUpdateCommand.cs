using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Memberships.Commands
{
    public class MembershipUpdateCommand : MembershipUpdateDto, IRequest<BaseApiResponse<MembershipSingleDto>>
    {
    }
}
