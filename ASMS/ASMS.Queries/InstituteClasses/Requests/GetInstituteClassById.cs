using ASMS.DTOs.InstituteClasses;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteClasses.Requests
{
    public class GetInstituteClassById : EntityByIdRequest<long>, IRequest<BaseApiResponse<InstituteClassSingleDto>>
    {
        public GetInstituteClassById(long id)
            : base(id)
        {
        }
    }
}