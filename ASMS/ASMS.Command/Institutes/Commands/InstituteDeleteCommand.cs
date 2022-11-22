using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Institutes.Commands
{
    public class InstituteDeleteCommand : IRequest<BaseApiResponse<InstituteSingleDto>>
    {
        public InstituteDeleteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
