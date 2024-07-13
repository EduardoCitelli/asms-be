using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;
using MediatR;
using System.Text.Json.Serialization;

namespace ASMS.Command.InstituteClasses.Commands
{
    public class UpdateInstituteClass : InstituteClassUpdateDto, IRequest<BaseApiResponse<bool>>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}