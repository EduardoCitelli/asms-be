using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Queries.Memberships.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Memberships.Handlers
{
    public class GetAllMembershipsForComboHandler : IRequestHandler<GetAllMembershipsForCombo, BaseApiResponse<IEnumerable<MembershipComboDto>>>
    {
        private readonly IMembershipService _service;

        public GetAllMembershipsForComboHandler(IMembershipService service)
        {
            _service = service;
        }

        public async Task<BaseApiResponse<IEnumerable<MembershipComboDto>>> Handle(GetAllMembershipsForCombo request, CancellationToken cancellationToken)
        {
            return await _service.GetForComboAsync();
        }
    }
}
