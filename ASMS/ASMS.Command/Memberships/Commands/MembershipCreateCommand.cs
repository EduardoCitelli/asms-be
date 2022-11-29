using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Memberships.Commands
{
    public class MembershipCreateCommand : MembershipCreateDto, IRequest<BaseApiResponse<MembershipSingleDto>>
    {
    }
}
