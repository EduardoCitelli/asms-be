using ASMS.Domain;

namespace ASMS.Persistence.Abstractions
{
    public interface IQueryRepository<TEntity, in TKey> : ICommandRepository<TEntity> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);

        Task<bool> ExistAsync(TKey id);

        Task<TEntity?> GetLastAsync();

        public IQueryable<TEntity> GetQueryable();        
    }
}
