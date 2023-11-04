using ASMS.Command.InstituteMembers.Commands;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.InstituteMembers.Handlers
{
    public class InstituteMemberUpdateHandler : IRequestHandler<InstituteMemberUpdateCommand, BaseApiResponse<InstituteMemberSingleDto>>
    {
        private readonly IInstituteMemberService _instituteMemberService;

        public InstituteMemberUpdateHandler(IInstituteMemberService instituteMemberService)
        {
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> Handle(InstituteMemberUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _instituteMemberService.UpdateAsync(request);
        }
    }
}
