using ASMS.Domain;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services
{
    public abstract partial class ServiceBase<TEntity, TKey, TSingleDto, TListDto> where TEntity : BaseEntity<TKey>
    {
        public async Task<TEntity> GetEntityByIdAsync(TKey key, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            return await TryGetExistentEntityBaseAsync(key, include);
        }
    }
}
