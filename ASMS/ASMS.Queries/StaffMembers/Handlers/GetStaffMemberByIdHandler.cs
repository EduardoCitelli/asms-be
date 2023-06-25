using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Queries.StaffMembers.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.StaffMembers.Handlers
{
    public class GetStaffMemberByIdHandler : IRequestHandler<GetStaffMemberById, BaseApiResponse<StaffMemberSingleDto>>
    {
        private readonly IStaffMemberService _staffMemberService;

        public GetStaffMemberByIdHandler(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> Handle(GetStaffMemberById request, CancellationToken cancellationToken)
        {
            return await _staffMemberService.GetOneAsync(request.Id);
        }
    }
}
