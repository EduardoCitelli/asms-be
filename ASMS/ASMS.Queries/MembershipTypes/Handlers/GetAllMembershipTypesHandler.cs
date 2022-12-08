using ASMS.CrossCutting.Utils;
using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using ASMS.Queries.MembershipTypes.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.MembershipTypes.Handlers
{
    public class GetAllMembershipTypesHandler : IRequestHandler<GetAllMembershipTypes, BaseApiResponse<PagedList<MembershipTypeListDto>>>
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public GetAllMembershipTypesHandler(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        public async Task<BaseApiResponse<PagedList<MembershipTypeListDto>>> Handle(GetAllMembershipTypes request, CancellationToken cancellationToken)
        {
            return await _membershipTypeService.GetListAsync(request.Page, request.Size);
        }
    }
}