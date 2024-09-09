namespace ASMS.Persistence.Abstractions
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(IEnumerable<TEntity> entities);
        void DetachEntity<TCommonEntity>(TCommonEntity entity) where TCommonEntity : class;

        void DetachEntity<TCommonEntity>(IEnumerable<TCommonEntity> entities) where TCommonEntity : class;
    }
}
