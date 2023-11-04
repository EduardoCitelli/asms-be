using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteMembers.Commands
{
    public class InstituteMemberCreateCommand : InstituteMemberCreateDto, IRequest<BaseApiResponse<InstituteMemberSingleDto>>
    {
    }
}
