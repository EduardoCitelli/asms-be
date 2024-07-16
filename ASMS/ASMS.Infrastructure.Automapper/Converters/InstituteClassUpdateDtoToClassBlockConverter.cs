using ASMS.CrossCutting.Extensions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClasses;
using AutoMapper;

namespace ASMS.Infrastructure.Automapper.Converters
{
    public class InstituteClassUpdateDtoToClassBlockConverter : ITypeConverter<InstituteClassUpdateDto, IEnumerable<InstituteClassBlock>>
    {
        public IEnumerable<InstituteClassBlock> Convert(InstituteClassUpdateDto source, IEnumerable<InstituteClassBlock> destination, ResolutionContext context)
        {
            if (source == null)
                return new List<InstituteClassBlock>();

            foreach(var block in destination)
                context.Mapper.Map(source, block);

            return destination;
        }
    }
}