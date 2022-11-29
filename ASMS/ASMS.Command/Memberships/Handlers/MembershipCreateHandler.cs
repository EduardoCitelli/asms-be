using ASMS.Command.Memberships.Commands;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Memberships.Handlers
{
    public class MembershipCreateHandler : IRequestHandler<MembershipCreateCommand, BaseApiResponse<MembershipSingleDto>>
    {
        private readonly IMembershipService _membershipService;

        public MembershipCreateHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> Handle(MembershipCreateCommand request, CancellationToken cancellationToken)
        {
            return await _membershipService.CreateAsync(request);
        }
    }
}