using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteClasses.Commands
{
    public class CreateInstituteClass : InstituteClassCreateDto, IRequest<BaseApiResponse<bool>>
    {
    }
}
