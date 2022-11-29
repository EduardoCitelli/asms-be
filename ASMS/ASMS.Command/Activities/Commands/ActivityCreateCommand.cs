using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Activities.Commands
{
    public class ActivityCreateCommand : ActivityCreateDto, IRequest<BaseApiResponse<ActivitySingleDto>>
    {
    }
}