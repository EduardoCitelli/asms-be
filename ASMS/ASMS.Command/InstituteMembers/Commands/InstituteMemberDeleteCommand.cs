using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteMembers.Commands
{
    public class InstituteMemberDeleteCommand : IRequest<BaseApiResponse<InstituteMemberSingleDto>>
    {
        public InstituteMemberDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}