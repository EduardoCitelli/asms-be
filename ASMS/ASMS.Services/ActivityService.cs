using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Activities;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class ActivityService : ServiceBase<Activity, long, ActivitySingleDto, ActivityListDto>, IActivityService
    {
        public ActivityService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Activity), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<ActivityListDto>>> GetListAsync(int pageNumber = 1,
                                                                                    int pageSize = 10,
                                                                                    Expression<Func<Activity, bool>>? query = null,
                                                                                    Func<IQueryable<Activity>, IIncludableQueryable<Activity, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> CreateAsync(ActivityCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> UpdateAsync(ActivityUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id);
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }

        public async Task<bool> AnyAsync(Expression<Func<Activity, bool>> query,
                                         Func<IQueryable<Activity>, IIncludableQueryable<Activity, object>>? include = null)
        {
            return await ExistBaseAsync(query, include);
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> GetForComboAsync()
        {
            return await GetForComboBaseAsync();
        }
    }
}