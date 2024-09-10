using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class InstituteService : ServiceBase<Institute, long, InstituteSingleDto, InstituteListDto>, IInstituteService
    {
        public InstituteService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Institute), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<InstituteListDto>>> GetListAsync(int pageNumber = 1,
                                                                                     int pageSize = 10,
                                                                                     Expression<Func<Institute, bool>>? query = null,
                                                                                     Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Create(InstituteCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Update(InstituteUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id);
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Delete(long id)
        {
            return await DeleteBaseAsync(id);
        }

        public async Task<bool> Any(Expression<Func<Institute, bool>> query,
                                    Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>>? include = null)
        {
            return await ExistBaseAsync(query, include);
        }

        public async Task<BaseApiResponse<bool>> SetDisableInstitute(long instituteId, Action<Institute> businessLogic)
        {
            var entity = await TryGetExistentEntityBaseAsync(instituteId, x => x.Include(x => x.InstitutePlans));

            businessLogic.Invoke(entity);

            await _repository.UpdateAsync(entity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<bool>(true);

            var message = $"Problem while saving {_entityName} changes";
            throw new InternalErrorException(message);
        }

        public async Task ValidateCanAddMembers()
        {
            var institute = await TryGetExistentEntityBaseAsync(_instituteIdService.InstituteId, InstituteInclude());

            if (!institute.IsEnabled)
                throw new BadRequestException("The institute is disabled");

            var activePlan = institute.InstitutePlans.FirstOrDefault(x => x.IsCurrentPlan);

            if (activePlan == null)
                throw new BadRequestException("The institue doesn't have an active plan");

            if (activePlan.Plan.AllowedUsers <= institute.InstituteMembers.Where(x => x.IsEnabled).Count())
                throw new BadRequestException("Institute members limit exceed");
        }

        private static Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>> InstituteInclude()
        {
            return x => x.Include(x => x.InstitutePlans)
                         .ThenInclude(x => x.Plan)
                         .Include(x => x.InstituteMembers);
        }
    }
}
