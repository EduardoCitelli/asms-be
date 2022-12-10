using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Queries.MembershipTypes.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.MembershipTypes.Handlers
{
    public class GetAllMembershipTypesForComboHandler : IRequestHandler<GetAllMembershipTypesForCombo, BaseApiResponse<IEnumerable<ComboDto<long>>>>
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public GetAllMembershipTypesForComboHandler(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> Handle(GetAllMembershipTypesForCombo request, CancellationToken cancellationToken)
        {
            return await _membershipTypeService.GetForComboAsync();
        }
    }
}