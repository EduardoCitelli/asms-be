using ASMS.Domain;
using ASMS.Persistence.Abstractions;

namespace ASMS.Persistence
{
    public class Repository<TEntity, TKey> : ComplexQueryRepository<TEntity, TKey>, IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Repository(ASMSDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
