using ASMS.Command.Coaches.Commands;
using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Security;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Coaches.Handlers
{
    public class CoachCreateHandler : IRequestHandler<CoachCreateCommand, BaseApiResponse<CoachSingleDto>>
    {
        private readonly ICoachService _coachService;
        private readonly IUserService _userService;

        public CoachCreateHandler(ICoachService coachService, IUserService userService)
        {
            _coachService = coachService;
            _userService = userService;
        }

        public async Task<BaseApiResponse<CoachSingleDto>> Handle(CoachCreateCommand request, CancellationToken cancellationToken)
        {
            await _userService.ValidateExistentInfo(request.User.UserName, request.User.Email);

            request.User.Password = request.User.Password.ToHash();
            request.User.Email = request.User.Email.ToLower();

            return await _coachService.CreateAsync(request);
        }
    }
}