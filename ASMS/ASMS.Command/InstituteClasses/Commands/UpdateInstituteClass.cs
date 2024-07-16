using ASMS.DTOs.InstituteClasses;
using ASMS.Infrastructure;
using MediatR;
using System.Text.Json.Serialization;

namespace ASMS.Command.InstituteClasses.Commands
{
    public class UpdateInstituteClass : InstituteClassUpdateDto, IRequest<BaseApiResponse<InstituteClassSingleDto>>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}