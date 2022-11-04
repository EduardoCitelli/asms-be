using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Plans.Request
{
    public class PlanCreateCommand : PlanCreateDto, IRequest<BaseApiResponse<PlanSingleDto>>
    {
    }
}
