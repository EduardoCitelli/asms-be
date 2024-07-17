using ASMS.DTOs.InstituteClassBlocks;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.InstituteClassBlocks.Requests
{
    public class GetClassBlockById : EntityByIdRequest<long>, IRequest<BaseApiResponse<InstituteClassBlockSingleDto>>
    {
        public GetClassBlockById(long id)
            : base(id)
        {
        }
    }
}