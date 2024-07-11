using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteClass.Commands
{
    public class CreateInstituteClass : InstituteClassCreateDto, IRequest<BaseApiResponse<bool>>
    {
    }
}
