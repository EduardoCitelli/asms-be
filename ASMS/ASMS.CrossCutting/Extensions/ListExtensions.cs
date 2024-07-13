namespace ASMS.CrossCutting.Extensions
{
    using ASMS.CrossCutting.Utils;
    using Microsoft.EntityFrameworkCore;

    public static partial class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
        {
            return source == null || !source.Any();
        }

        public async static Task<PagedList<T>> ToPagedList<T>(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            var items = await source.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}