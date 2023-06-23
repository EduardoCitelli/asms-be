using ASMS.DTOs.MembershipTypes;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.MembershipTypes.Requests
{
    public class GetMembershipTypeById : EntityByIdRequest<long>, IRequest<BaseApiResponse<MembershipTypeSingleDto>>
    {
        public GetMembershipTypeById(long id) : base(id)
        {
        }
    }
}
