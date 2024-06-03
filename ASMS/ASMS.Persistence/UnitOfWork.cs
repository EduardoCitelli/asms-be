using ASMS.CrossCutting.Extensions;
using ASMS.Domain;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ASMS.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ASMSDbContext _dbContext;
        private readonly Dictionary<string, object> _repositories;

        public UnitOfWork(ASMSDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<string, object>();
        }

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var name = StringExtensions.GetRepositoryName<TEntity>();

            if (!_repositories.ContainsKey(name))
            {
                var repository = CreateRepository<TEntity, TKey>(name);
                _repositories.Add(name, repository);
            }

            var repositoryValue = (IRepository<TEntity, TKey>)_repositories[name];

            return repositoryValue ?? throw new InternalErrorException($"Repository {name} not found");
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            var cancellationToken = new CancellationToken();

            try
            {
                var result = await _dbContext.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException uce)
            {
                var exceptionEntry = uce.Entries.Single();

                var databaseEntry = await exceptionEntry.GetDatabaseValuesAsync(cancellationToken);

                if (databaseEntry == null)
                    throw new NotFoundException("Unable to save changes. The record was deleted by another user.");
                else
                    throw new BaseException("The record you attempted to edit "
                                          + "was modified by another user after you got the original value. Your "
                                          + "edit operation was canceled. Please close this form and query this record again and try to save later",
                                          HttpStatusCode.Conflict);
            }
            catch (DbUpdateException uex)
            {
                throw new InternalErrorException($"Error while updating. Detail error {uex}");
            }
            catch (Exception ex)
            {
                throw new InternalErrorException($"Error while saving. Detail error {ex}");
            }
        }

        protected virtual IRepository<TEntity, TKey> CreateRepository<TEntity, TKey>(string name) where TEntity : BaseEntity<TKey> => new Repository<TEntity, TKey>(_dbContext);
    }
}
