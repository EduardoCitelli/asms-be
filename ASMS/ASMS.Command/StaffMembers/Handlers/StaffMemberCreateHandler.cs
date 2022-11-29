using ASMS.Command.StaffMembers.Commands;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.StaffMembers.Handlers
{
    public class StaffMemberCreateHandler : IRequestHandler<StaffMemberCreateCommand, BaseApiResponse<StaffMemberSingleDto>>
    {
        private readonly IStaffMemberService _staffMemberService;

        public StaffMemberCreateHandler(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> Handle(StaffMemberCreateCommand request, CancellationToken cancellationToken)
        {
            return await _staffMemberService.CreateAsync(request);
        }
    }
}