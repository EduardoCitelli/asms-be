using ASMS.Domain;
using ASMS.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services
{
    public abstract partial class ServiceBase<TEntity, TKey, TSingleDto, TListDto> where TEntity : BaseEntity<TKey>
    {
        public async Task<TEntity> GetEntityByIdAsync(TKey key, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            return await TryGetExistentEntityBaseAsync(key, include);
        }

        public async Task ValidateExistingAsync(TKey key)
        {
            var exist = await ExistBaseAsync(key);

            if (!exist)
            {
                var message = $"Entity: {_entityName} with key: {key} does not exist";
                throw new NotFoundException(message);
            }
        }

        public async Task UpdateEntity(TEntity entity,
                                       IEnumerable<object>? entitesToDetach = null)
        {
            if (entitesToDetach != null && entitesToDetach.Any())
                _repository.DetachEntity(entitesToDetach);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateEntityAsync(IEnumerable<TEntity> entity,
                                            IEnumerable<object>? entitesToDetach = null)
        {
            if (entitesToDetach != null && entitesToDetach.Any())
                _repository.DetachEntity(entitesToDetach);

            await _repository.UpdateAsync(entity);
        }

        public async Task AddEntityAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task AddEntityAsync(IEnumerable<TEntity> entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task DeleteEntityAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task DeleteEntityAsync(IEnumerable<TEntity> entity)
        {
            await _repository.DeleteAsync(entity);
        }
    }
}
