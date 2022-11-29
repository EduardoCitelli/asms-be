using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Coaches.Commands
{
    public class CoachUpdateCommand : CoachUpdateDto, IRequest<BaseApiResponse<CoachSingleDto>>
    {
    }
}
