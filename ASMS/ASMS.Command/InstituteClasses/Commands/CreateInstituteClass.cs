using ASMS.DTOs.InstituteClasses;
using ASMS.Infrastructure;
using MediatR;

namespace ASMS.Command.InstituteClasses.Commands
{
    public class CreateInstituteClass : InstituteClassCreateDto, IRequest<BaseApiResponse<InstituteClassSingleDto>>
    {
    }
}