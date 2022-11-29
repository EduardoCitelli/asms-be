using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Coaches.Commands
{
    public class CoachCreateCommand : CoachCreateDto, IRequest<BaseApiResponse<CoachSingleDto>>
    {
    }
}
