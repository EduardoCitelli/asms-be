using ASMS.DTOs.InstituteMembers;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteMembers.Requests
{
    public class GetInstituteMemberById : EntityByIdRequest<long>, IRequest<BaseApiResponse<InstituteMemberSingleDto>>
    {
        public GetInstituteMemberById(long id) 
            : base(id)
        {
        }
    }
}
