using ASMS.Domain;

namespace ASMS.Persistence.Abstractions
{
    public interface IRepository<TEntity, in TKey>
        : IComplexQueryRespository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
    }
}