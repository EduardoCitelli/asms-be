using AutoMapper;

namespace ASMS.Infrastructure.Automapper.Converters
{
    public class SingleObjectToListConverter<T, T2> : ITypeConverter<T, ICollection<T2>>
    {
        public ICollection<T2> Convert(T source, ICollection<T2> destination, ResolutionContext context)
        {
            return new List<T2>() { context.Mapper.Map<T2>(source) };
        }
    }
}
