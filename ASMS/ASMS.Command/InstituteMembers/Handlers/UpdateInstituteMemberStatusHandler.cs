using ASMS.Command.InstituteMembers.Commands;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Command.InstituteMembers.Handlers
{
    public class UpdateInstituteMemberStatusHandler : IRequestHandler<UpdateInstituteMemberStatusCommand, BaseApiResponse<bool>>
    {
        private readonly IInstituteMemberService _instituteMemberService;

        public UpdateInstituteMemberStatusHandler(IInstituteMemberService instituteMemberService)
        {
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<bool>> Handle(UpdateInstituteMemberStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _instituteMemberService.UpdateAsync(request, SetMembershipInactive(), x => x.Include(y => y.Memberships));

            return new BaseApiResponse<bool>(response != null);
        }

        private static Action<UpdateStatusInstituteMemberDto, InstituteMember> SetMembershipInactive()
        {
            return (dto, entity) =>
            {
                if (!dto.IsEnabled)
                {
                    var activeMembership = entity.Memberships.Where(x => x.IsActiveMembership);

                    foreach (var membership in activeMembership)
                        membership.IsActiveMembership = false;
                }
            };
        }
    }
}
