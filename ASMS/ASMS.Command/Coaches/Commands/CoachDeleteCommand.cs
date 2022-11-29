using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Coaches.Commands
{
    public class CoachDeleteCommand : IRequest<BaseApiResponse<CoachSingleDto>>
    {
        public CoachDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
