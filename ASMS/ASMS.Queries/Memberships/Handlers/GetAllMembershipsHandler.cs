using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Queries.Memberships.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Memberships.Handlers
{
    public class GetAllMembershipsHandler : IRequestHandler<GetAllMemberships, BaseApiResponse<PagedList<MembershipListDto>>>
    {
        private readonly IMembershipService _membershipService;

        public GetAllMembershipsHandler(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public async Task<BaseApiResponse<PagedList<MembershipListDto>>> Handle(GetAllMemberships request, CancellationToken cancellationToken)
        {
            return await _membershipService.GetListAsync(request.Page, request.Size);
        }
    }
}