using ASMS.DTOs.Shared;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.StaffMembers.Requests
{
    public class GetStaffMemberById : EntityByIdRequest<long>, IRequest<BaseApiResponse<StaffMemberSingleDto>>
    {
        public GetStaffMemberById(long id) : base(id)
        {
        }
    }
}
