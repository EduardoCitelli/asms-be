using AutoMapper;

namespace ASMS.Infrastructure.Automapper.Converters
{
    public class SingleObjectToListConverter<TSource, TDestination> : ITypeConverter<TSource, ICollection<TDestination>>
    {
        public ICollection<TDestination> Convert(TSource source, ICollection<TDestination> destination, ResolutionContext context)
        {
            return source == null ? new List<TDestination>() : new List<TDestination>() { context.Mapper.Map<TDestination>(source) };
        }
    }
}
