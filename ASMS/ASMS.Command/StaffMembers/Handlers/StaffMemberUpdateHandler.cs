using ASMS.Command.StaffMembers.Commands;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.StaffMembers.Handlers
{
    public class StaffMemberUpdateHandler : IRequestHandler<StaffMemberUpdateCommand, BaseApiResponse<StaffMemberSingleDto>>
    {
        private readonly IStaffMemberService _staffMemberService;

        public StaffMemberUpdateHandler(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> Handle(StaffMemberUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _staffMemberService.UpdateAsync(request);
        }
    }
}