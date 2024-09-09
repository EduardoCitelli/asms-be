using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMembers;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class InstituteMemberService : ServiceBase<InstituteMember, long, InstituteMemberSingleDto, InstituteMemberListDto>, IInstituteMemberService
    {
        public InstituteMemberService(IUnitOfWork uow, 
                                      IMapper mapper, 
                                      IInstituteIdService instituteIdService)
            : base(uow, nameof(InstituteMember), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<InstituteMemberListDto>>> GetListAsync(int pageNumber = 1,
                                                                                           int pageSize = 10,
                                                                                           Expression<Func<InstituteMember, bool>>? query = null,
                                                                                           Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id, x => x.Include(x => x.User));
        }

        public async Task<IList<InstituteMember>> GetEntityListAsync(Expression<Func<InstituteMember, bool>>? query = null,
                                                                     Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null,
                                                                     Expression<Func<InstituteMember, object>>? orderBy = null,
                                                                     bool isDesc = false)
        {
            var result = query is null ? _repository.GetAll(include, orderBy, isDesc) : _repository.Find(query, include, orderBy, isDesc);
            return await result.ToListAsync();
        }

        public async Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> GetForComboAsync(Expression<Func<InstituteMember, bool>>? query = null,
                                                                                         Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null)
        {
            return await GetForComboBaseAsync(query, include);
        }

        public async Task<bool> ExistAsync(Expression<Func<InstituteMember, bool>> query,
                                           Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null)
        {
            return await ExistBaseAsync(query, include);
        }

        public async Task<bool> ExistIdsAsync(IEnumerable<long> ids)
        {
            return await ExistBaseAsync(ids);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> CreateAsync(InstituteMemberCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> UpdateAsync(InstituteMemberUpdateDto dto,
                                                                                 Action<InstituteMemberUpdateDto, InstituteMember>? beforeToSaveAction = null)
        {
            return await UpdateBaseAsync(dto, dto.Id, beforeToSaveAction, x => x.Include(x => x.User));
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> UpdateAsync(UpdateStatusInstituteMemberDto dto,
                                                                                 Action<UpdateStatusInstituteMemberDto, InstituteMember>? beforeToSaveAction = null,
                                                                                 Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null)
        {
            return await UpdateBaseAsync(dto, dto.Id, beforeToSaveAction, include);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }

        public async Task SetActivitiesToInstituteMemberWithoutSaveAsync(long instituteMemberId, IEnumerable<long> activities)
        {
            var entity = await TryGetExistentEntityBaseAsync(instituteMemberId, x => x.Include(x => x.AllowedActivities));

            entity.AllowedActivities = activities.Select(x => new InstituteMemberActivities
            {
                ActivityId = x,
            }).ToList();

            await _repository.UpdateAsync(entity);
        }
    }
}