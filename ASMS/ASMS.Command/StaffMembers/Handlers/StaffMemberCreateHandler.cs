using ASMS.Command.StaffMembers.Commands;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Security;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.StaffMembers.Handlers
{
    public class StaffMemberCreateHandler : IRequestHandler<StaffMemberCreateCommand, BaseApiResponse<StaffMemberSingleDto>>
    {
        private readonly IStaffMemberService _staffMemberService;
        private readonly IUserService _userService;

        public StaffMemberCreateHandler(IStaffMemberService staffMemberService, IUserService userService)
        {
            _staffMemberService = staffMemberService;
            _userService = userService;
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> Handle(StaffMemberCreateCommand request, CancellationToken cancellationToken)
        {
            await _userService.ValidateExistentInfo(request.User.UserName, request.User.Email);

            request.User.Password = request.User.Password.ToHash();
            request.User.Email = request.User.Email.ToLower();

            return await _staffMemberService.CreateAsync(request);
        }
    }
}