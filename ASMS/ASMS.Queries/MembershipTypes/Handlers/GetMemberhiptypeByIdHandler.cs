using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using ASMS.Queries.MembershipTypes.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.MembershipTypes.Handlers
{
    public class GetMemberhiptypeByIdHandler : IRequestHandler<GetMembershipTypeById, BaseApiResponse<MembershipTypeSingleDto>>
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public GetMemberhiptypeByIdHandler(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> Handle(GetMembershipTypeById request, CancellationToken cancellationToken)
        {
            return await _membershipTypeService.GetOneAsync(request.Id);
        }
    }
}