using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.DTOs.Activities;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class ActivityService : ServiceBase<Activity, long, ActivitySingleDto, ActivityListDto>, IActivityService
    {
        private readonly IInstituteIdService _instituteIdService;

        public ActivityService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Activity), mapper)
        {
            _instituteIdService = instituteIdService;
        }

        public async Task<BaseApiResponse<ActivitySingleDto>> CreateAsync(ActivityCreateDto dto)
        {
            var action = (Activity entity) => 
            {
                if (_instituteIdService.InstituteId <= 0)
                    throw new BadRequestException("Not received Instititute Id");

                entity.InstituteId = _instituteIdService.InstituteId; 
            };

            return await CreateBaseAsync(dto, action);
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
    }
}