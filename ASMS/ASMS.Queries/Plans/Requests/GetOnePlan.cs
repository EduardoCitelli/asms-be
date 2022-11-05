namespace ASMS.Queries.Plans.Requests
{
    using ASMS.DTOs.Plans;
    using ASMS.Infrastructure;
    using MediatR;

    public class GetOnePlan : IRequest<BaseApiResponse<PlanSingleDto>>
    {
        public GetOnePlan(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}