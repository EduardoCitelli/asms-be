using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteMembers.Commands
{
    public class UpdateInstituteMemberStatusCommand : UpdateStatusInstituteMemberDto, IRequest<BaseApiResponse<bool>>
    {
    }
}
