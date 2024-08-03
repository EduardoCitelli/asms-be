using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClassBlocks;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IInstituteClassBlockService
    {
        Task<BaseApiResponse<PagedList<InstituteClassBlockListDto>>> GetAllDtosPaginatedAsync(PagedFilterRequestDto request,
                                                                                              Expression<Func<InstituteClassBlock, bool>>? query = null,
                                                                                              Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null,
                                                                                              Expression<Func<InstituteClassBlock, object>>? orderBy = null,
                                                                                              bool isDesc = false);

        Task<IEnumerable<TDto>> GetListDtoAsync<TDto>(Expression<Func<InstituteClassBlock, bool>>? query = null, 
                                                      Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null, 
                                                      Expression<Func<InstituteClassBlock, object>>? orderBy = null, 
                                                      bool isDesc = false);

        Task<BaseApiResponse<InstituteClassBlockSingleDto>> GetOneDtoAsync(long key,
                                                                           Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null);

        Task<InstituteClassBlock> TryGetExistentEntityAsync(long key, 
                                                            Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null);

        Task<bool> UpdateEntityAsync(InstituteClassBlock entity);

        Task UpdateStatusFromActiveToFinished();

        Task<IEnumerable<InstituteClassBlock>> GetInactiveClassesToCancel();

        Task<bool> ValidateExistentAsync(Expression<Func<InstituteClassBlock, bool>> query,
                                         Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object>>? include = null);
    }
}