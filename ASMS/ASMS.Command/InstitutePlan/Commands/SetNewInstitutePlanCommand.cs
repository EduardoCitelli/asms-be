using ASMS.DTOs.InstitutePlan;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstitutePlan.Commands
{
    public class SetNewInstitutePlanCommand : InstitutePlanCreateDto, IRequest<BaseApiResponse<bool>>
    {
    }
}
