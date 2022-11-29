using ASMS.Command.StaffMembers.Commands;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.StaffMembers.Handlers
{
    public class StaffMemberDeleteHandler : IRequestHandler<StaffMemberDeleteCommand, BaseApiResponse<StaffMemberSingleDto>>
    {
        private readonly IStaffMemberService _staffMemberService;

        public StaffMemberDeleteHandler(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> Handle(StaffMemberDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _staffMemberService.DeleteAsync(request.Id);
        }
    }
}