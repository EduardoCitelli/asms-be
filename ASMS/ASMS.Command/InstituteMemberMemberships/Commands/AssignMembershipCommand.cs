using ASMS.DTOs.InstituteMemberMemberships;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteMemberMemberships.Commands
{
    public class AssignMembershipCommand : InstituteMemberMembershipCreateDto, IRequest<BaseApiResponse<long>>
    {
    }
}
