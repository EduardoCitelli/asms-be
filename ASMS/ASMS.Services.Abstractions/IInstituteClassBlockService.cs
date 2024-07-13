using ASMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteClassBlockService
    {
        Task UpdateStatusFromNewToFinished();
        Task<bool> ValidateExistentAsync(Expression<Func<InstituteClassBlock, bool>> query,
                                         Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object>>? include = null);
    }
}