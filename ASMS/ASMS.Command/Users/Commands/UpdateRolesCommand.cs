using ASMS.CrossCutting.Enums;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Users.Commands
{
    public class UpdateRolesCommand : EntityByIdRequest<long>, IRequest<BaseApiResponse<bool>>
    {
        public UpdateRolesCommand(long userId, IEnumerable<RoleTypeEnum> roles) 
            : base(userId)
        {
            Roles = roles;
        }

        public IEnumerable<RoleTypeEnum> Roles { get; set; } = new List<RoleTypeEnum>();
    }
}
