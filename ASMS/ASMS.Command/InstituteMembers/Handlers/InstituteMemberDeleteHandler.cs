using ASMS.Command.InstituteMembers.Commands;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.InstituteMembers.Handlers
{
    public class InstituteMemberDeleteHandler : IRequestHandler<InstituteMemberDeleteCommand, BaseApiResponse<InstituteMemberSingleDto>>
    {
        private readonly IInstituteMemberService _instituteMemberService;

        public InstituteMemberDeleteHandler(IInstituteMemberService instituteMemberService)
        {
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> Handle(InstituteMemberDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _instituteMemberService.DeleteAsync(request.Id);
        }
    }
}