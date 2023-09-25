using ASMS.DTOs.Institutes;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Institutes.Requests
{
    public class GetInstituteById : EntityByIdRequest<long>, IRequest<BaseApiResponse<InstituteSingleDto>>
    {
        public GetInstituteById(long id)
            : base(id)
        {
        }
    }
}
