using ASMS.Command.Memberships.Commands;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Memberships.Handlers
{
    public class MembershipDeleteHandler : IRequestHandler<MembershipDeleteCommand, BaseApiResponse<MembershipSingleDto>>
    {
        private readonly IMembershipService _membershipService;

        public MembershipDeleteHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> Handle(MembershipDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _membershipService.DeleteAsync(request.Id);
        }
    }
}