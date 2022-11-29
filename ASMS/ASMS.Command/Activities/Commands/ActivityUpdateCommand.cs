using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Activities.Commands
{
    public class ActivityUpdateCommand : ActivityUpdateDto, IRequest<BaseApiResponse<ActivitySingleDto>>
    {
    }
}