using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteMembers.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.InstituteMembers.Handlers
{
    public class GetInstituteMemberByIdHandler : IRequestHandler<GetInstituteMemberById, BaseApiResponse<InstituteMemberSingleDto>>
    {
        private readonly IInstituteMemberService _instituteMemberService;

        public GetInstituteMemberByIdHandler(IInstituteMemberService instituteMemberService)
        {
            _instituteMemberService = instituteMemberService;
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> Handle(GetInstituteMemberById request, CancellationToken cancellationToken)
        {
            return await _instituteMemberService.GetOneAsync(request.Id);
        }
    }
}