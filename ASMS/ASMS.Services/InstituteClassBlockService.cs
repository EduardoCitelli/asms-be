using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClassBlocks;
using ASMS.DTOs.Shared;
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
    public class InstituteClassBlockService : IInstituteClassBlockService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<InstituteClassBlock, long> _repository;

        public InstituteClassBlockService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _repository = _uow.GetRepository<InstituteClassBlock, long>();
        }

        public async Task<bool> ValidateExistentAsync(Expression<Func<InstituteClassBlock, bool>> query,
                                                      Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object>>? include = null)
        {
            return await _repository.FindExistAsync(query, include);
        }

        public async Task UpdateStatusFromActiveToFinished()
        {
            var response = await _repository.Find(x => x.ClassStatus == ClassStatus.Active && x.StartDateTime < DateTime.UtcNow)
                                            .ToListAsync();

            if (response.Any())
            {
                foreach (var block in response)
                    block.ClassStatus = ClassStatus.Finished;

                await _repository.UpdateCollectionAsync(response);
                await _uow.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InstituteClassBlock>> GetInactiveClassesToCancel()
        {
            return await _repository.Find(x => x.ClassStatus == ClassStatus.Pending && x.StartDateTime < DateTime.UtcNow)
                                    .ToListAsync();
        }

        public async Task<bool> UpdateEntityAsync(InstituteClassBlock entity)
        {
            await _repository.UpdateAsync(entity);
            var success = await _uow.SaveChangesAsync() > 0;

            if (!success)
            {
                var message = $"Problem while saving institute class block changes";
                throw new InternalErrorException(message);
            }

            return success;
        }

        public async Task<BaseApiResponse<PagedList<InstituteClassBlockListDto>>> GetAllDtosPaginatedAsync(PagedFilterRequestDto request,
                                                                                                           Expression<Func<InstituteClassBlock, bool>>? query = null,
                                                                                                           Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null,
                                                                                                           Expression<Func<InstituteClassBlock, object>>? orderBy = null,
                                                                                                           bool isDesc = false)
        {
            var result = query is null ? _repository.GetAll(include, orderBy, isDesc) : _repository.Find(query, include, orderBy, isDesc);

            if (request.RootFilter != null)
                result = result.ApplyFilter(request.RootFilter);

            var dtos = _mapper.ProjectTo<InstituteClassBlockListDto>(result);

            var pagedResponse = await ListExtensions.ToPagedList(dtos, request.Page, request.Size);

            return new BaseApiResponse<PagedList<InstituteClassBlockListDto>>(pagedResponse);
        }

        public async Task<BaseApiResponse<InstituteClassBlockSingleDto>> GetOneDtoAsync(long key,
                                                                                        Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null)
        {
            var result = await TryGetExistentEntityAsync(key, include);

            var dto = _mapper.Map<InstituteClassBlockSingleDto>(result);

            return new BaseApiResponse<InstituteClassBlockSingleDto>(dto);
        }

        public async Task<IEnumerable<TDto>> GetListDtoAsync<TDto>(Expression<Func<InstituteClassBlock, bool>>? query = null,
                                                                   Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null,
                                                                   Expression<Func<InstituteClassBlock, object>>? orderBy = null,
                                                                   bool isDesc = false)
        {
            var result = query is null ? _repository.GetAll(include, orderBy, isDesc) : _repository.Find(query, include, orderBy, isDesc);

            var dtos = _mapper.ProjectTo<TDto>(result);

            return await dtos.ToListAsync();
        }

        public async Task<InstituteClassBlock> TryGetExistentEntityAsync(long key,
                                                                         Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>>? include = null)
        {
            var existentEntity = await _repository.GetByIdAsync(key, include);

            if (existentEntity == null)
            {
                var message = $"Entity: Class Block with key: {key} does not exist";
                throw new NotFoundException(message);
            }

            return existentEntity;
        }
    }
}
