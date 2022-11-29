using ASMS.Command.Memberships.Commands;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Memberships.Handlers
{
    public class MembershipUpdateHandler : IRequestHandler<MembershipUpdateCommand, BaseApiResponse<MembershipSingleDto>>
    {
        private readonly IMembershipService _membershipService;

        public MembershipUpdateHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> Handle(MembershipUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _membershipService.UpdateAsync(request);
        }
    }
}