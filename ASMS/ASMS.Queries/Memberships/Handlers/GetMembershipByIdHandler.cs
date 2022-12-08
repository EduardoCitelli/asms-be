using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Queries.Memberships.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Memberships.Handlers
{
    public class GetMembershipByIdHandler : IRequestHandler<GetMembershipById, BaseApiResponse<MembershipSingleDto>>
    {
        private readonly IMembershipService _membershipService;

        public GetMembershipByIdHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> Handle(GetMembershipById request, CancellationToken cancellationToken)
        {
            return await _membershipService.GetOneAsync(request.Id);
        }
    }
}
