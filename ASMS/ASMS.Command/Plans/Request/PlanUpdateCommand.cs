using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Plans.Request
{
    public class PlanUpdateCommand : PlanUpdateDto, IRequest<BaseApiResponse<PlanSingleDto>>
    {
    }
}