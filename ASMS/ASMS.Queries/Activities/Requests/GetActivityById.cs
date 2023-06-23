using ASMS.DTOs.Activities;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Queries.Activities.Requests
{
    public class GetActivityById : EntityByIdRequest<long>, IRequest<BaseApiResponse<ActivitySingleDto>>
    {
        public GetActivityById(long id) : base(id)
        {
        }
    }
}
