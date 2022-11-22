using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.Institutes.Commands
{
    public class InstituteUpdateCommand : InstituteUpdateDto, IRequest<BaseApiResponse<InstituteSingleDto>>
    {
    }
}
