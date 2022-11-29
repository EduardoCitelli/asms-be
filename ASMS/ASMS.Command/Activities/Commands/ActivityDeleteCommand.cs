using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Activities.Commands
{
    public class ActivityDeleteCommand : IRequest<BaseApiResponse<ActivitySingleDto>>
    {
        public ActivityDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}