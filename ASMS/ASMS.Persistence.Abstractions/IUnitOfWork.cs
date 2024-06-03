using ASMS.Domain;

namespace ASMS.Persistence.Abstractions
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;

        Task<int> SaveChangesAsync();
    }
}
