using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Plans.Commands
{
    public class PlanDeleteCommand : IRequest<BaseApiResponse<PlanSingleDto>>
    {
        public PlanDeleteCommand(int planId)
        {
            PlanId = planId;
        }

        public int PlanId { get; set; }
    }
}