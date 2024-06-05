using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Institutes.Commands
{
    public class InstituteDisableCommand : IRequest<BaseApiResponse<bool>>
    {
        public InstituteDisableCommand(long instituteId)
        {
            InstituteId = instituteId;
        }

        public long InstituteId { get; set; }
    }
}