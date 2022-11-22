using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Plans.Commands
{
    public class PlanUpdateCommand : PlanUpdateDto, IRequest<BaseApiResponse<PlanSingleDto>>
    {
    }
}