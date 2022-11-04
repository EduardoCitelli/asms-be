using MediatR;

namespace ASMS.Queries.Plans.Requests
{
    public class GetAllPlans : IRequest<>
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;
    }
}