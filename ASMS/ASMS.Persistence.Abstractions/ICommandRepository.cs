namespace ASMS.Persistence.Abstractions
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task AddCollectionAsync(IEnumerable<TEntity> entities);

        Task UpdateCollectionAsync(IEnumerable<TEntity> entities);

        Task DeleteCollectionAsync(IEnumerable<TEntity> entities);
    }
}
