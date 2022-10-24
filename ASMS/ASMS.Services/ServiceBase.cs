using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public abstract class ServiceBase<TEntity, TKey, TSimpleDto, TListDto> where TEntity : BaseEntity<TKey>
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IRepository<TEntity, TKey> _repository;
        protected readonly IMapper _mapper;
        protected readonly string _entityName;
        protected readonly bool _isAuditEntity;

        protected ServiceBase(IUnitOfWork uow, string entityName, IMapper mapper)
        {
            _uow = uow;
            _repository = _uow.GetRepository<TEntity, TKey>()!;
            _mapper = mapper;
            _entityName = entityName;
            _isAuditEntity = typeof(TEntity) is AuditEntity<TKey>;
        }

        protected async Task<BaseApiResponse<IEnumerable<TListDto>>> GetAllDtosBaseAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var result = _repository.GetAll(include, null);

            var dtos = await _mapper.ProjectTo<TListDto>(result)
                                    .ToListAsync();

            return new BaseApiResponse<IEnumerable<TListDto>>(dtos);
        }

        protected async Task<BaseApiResponse<PagedList<TListDto>>> GetAllDtosBaseAsync(int pageNumber,
                                                                                       int pageSize,
                                                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var result = _repository.GetAll(include, null);

            var dtos = _mapper.ProjectTo<TListDto>(result);

            var pagedResponse = await ListExtensions.ToPagedList(dtos, pageNumber, pageSize);

            return new BaseApiResponse<PagedList<TListDto>>(pagedResponse);
        }

        protected async Task<BaseApiResponse<TSimpleDto>> GetOneDtoBaseAsync(TKey key)
        {
            var result = await TryGetExistentEntityByIdAsync(key);

            var dto = _mapper.Map<TSimpleDto>(result);

            return new BaseApiResponse<TSimpleDto>(dto);
        }

        protected async Task<BaseApiResponse<IEnumerable<TListDto>>> GetDtosByQueryBaseAsync(Expression<Func<TEntity, bool>> query,
                                                                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var result = _repository.Find(query, include, null);

            var dtos = await _mapper.ProjectTo<TListDto>(result)
                                    .ToListAsync();

            return new BaseApiResponse<IEnumerable<TListDto>>(dtos);
        }

        protected async Task<BaseApiResponse<PagedList<TListDto>>> GetDtosByQueryBaseAsync(int pageNumber,
                                                                                           int pageSize,
                                                                                           Expression<Func<TEntity, bool>> query,
                                                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var result = _repository.Find(query, include, null);

            var dtos = _mapper.ProjectTo<TListDto>(result);

            var pagedResponse = await ListExtensions.ToPagedList(dtos, pageNumber, pageSize);

            return new BaseApiResponse<PagedList<TListDto>>(pagedResponse);
        }

        protected async Task<BaseApiResponse<TSimpleDto>> CreateBaseAsync<TCreateDto>(TCreateDto request, Action<TEntity>? actionBeforeSave = null)
        {
            var newEntity = _mapper.Map<TEntity>(request);

            if (actionBeforeSave != null)
                actionBeforeSave.Invoke(newEntity);

            await _repository.AddAsync(newEntity);
            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
            {
                var response = _mapper.Map<TSimpleDto>(newEntity);
                return new BaseApiResponse<TSimpleDto>(response);
            }

            var message = $"Problem while saving {_entityName} changes";

            throw new InternalErrorException(message);
        }

        protected async Task<BaseApiResponse<TSimpleDto>> UpdateBaseAsync<TUpdateDto>(TUpdateDto request, TKey key, Action<TUpdateDto, TEntity>? beforeAction = null)
        {
            var entity = await TryGetExistentEntityByIdAsync(key);

            beforeAction?.Invoke(request, entity);

            entity = _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
            {
                var response = _mapper.Map<TSimpleDto>(entity);
                return new BaseApiResponse<TSimpleDto>(response);
            }

            var message = $"Problem while saving {_entityName} changes";

            throw new InternalErrorException(message);
        }

        protected async Task<BaseApiResponse<TSimpleDto>> DeleteBaseAsync(TKey key)
        {
            var entity = await TryGetExistentEntityByIdAsync(key);

            await _repository.DeleteAsync(entity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
            {
                var response = _mapper.Map<TSimpleDto>(entity);
                return new BaseApiResponse<TSimpleDto>(response);
            }

            var message = $"Problem while deleting {_entityName} changes";

            throw new InternalErrorException(message);
        }

        protected async Task<TEntity> TryGetExistentEntityByIdAsync(TKey key)
        {
            var existentEntity = await _repository.GetByIdAsync(key);

            if (existentEntity == null)
            {
                var message = $"Entity: {_entityName} with key: {key} does not exist";
                throw new NotFoundException(message);
            }

            return existentEntity;
        }
    }
}