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
    }
}
