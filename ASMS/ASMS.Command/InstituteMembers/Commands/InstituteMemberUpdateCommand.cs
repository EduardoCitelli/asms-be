using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteMembers.Commands
{
    public class InstituteMemberUpdateCommand : InstituteMemberUpdateDto, IRequest<BaseApiResponse<InstituteMemberSingleDto>>
    {
    }
}
