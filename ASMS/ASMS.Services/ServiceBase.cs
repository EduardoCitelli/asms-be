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
    public abstract class ServiceBase<TEntity, TKey, TSingleDto, TListDto> where TEntity : BaseEntity<TKey>
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

        protected async Task<BaseApiResponse<PagedList<TListDto>>> GetAllDtosPaginatedBaseAsync(int pageNumber = 1,
                                                                                                int pageSize = 10,
                                                                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var result = _repository.GetAll(include, null);

            var dtos = _mapper.ProjectTo<TListDto>(result);

            var pagedResponse = await ListExtensions.ToPagedList(dtos, pageNumber, pageSize);

            return new BaseApiResponse<PagedList<TListDto>>(pagedResponse);
        }

        protected async Task<BaseApiResponse<TSingleDto>> GetOneDtoBaseAsync(TKey key)
        {
            var result = await TryGetExistentEntity(key);

            var dto = _mapper.Map<TSingleDto>(result);

            return new BaseApiResponse<TSingleDto>(dto);
        }

        protected async Task<BaseApiResponse<IEnumerable<TListDto>>> GetDtosByQueryBaseAsync(Expression<Func<TEntity, bool>> query,
                                                                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var result = _repository.Find(query, include, null);

            var dtos = await _mapper.ProjectTo<TListDto>(result)
                                    .ToListAsync();

            return new BaseApiResponse<IEnumerable<TListDto>>(dtos);
        }

        protected async Task<BaseApiResponse<PagedList<TListDto>>> GetDtoPaginatedsByQueryBaseAsync(Expression<Func<TEntity, bool>> query,
                                                                                                    int pageNumber = 1,
                                                                                                    int pageSize = 10,
                                                                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var result = _repository.Find(query, include, null);

            var dtos = _mapper.ProjectTo<TListDto>(result);

            var pagedResponse = await ListExtensions.ToPagedList(dtos, pageNumber, pageSize);

            return new BaseApiResponse<PagedList<TListDto>>(pagedResponse);
        }

        protected async Task<BaseApiResponse<TSingleDto>> CreateBaseAsync<TCreateDto>(TCreateDto request, Action<TEntity>? actionBeforeSave = null)
        {
            var newEntity = _mapper.Map<TEntity>(request);

            if (actionBeforeSave != null)
                actionBeforeSave.Invoke(newEntity);

            await _repository.AddAsync(newEntity);
            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
            {
                var response = _mapper.Map<TSingleDto>(newEntity);
                return new BaseApiResponse<TSingleDto>(response);
            }

            var message = $"Problem while saving {_entityName} changes";

            throw new InternalErrorException(message);
        }

        protected async Task<BaseApiResponse<TSingleDto>> UpdateBaseAsync<TUpdateDto>(TUpdateDto request, TKey key, Action<TUpdateDto, TEntity>? beforeAction = null)
        {
            var entity = await TryGetExistentEntity(key);

            beforeAction?.Invoke(request, entity);

            entity = _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
            {
                var response = _mapper.Map<TSingleDto>(entity);
                return new BaseApiResponse<TSingleDto>(response);
            }

            var message = $"Problem while saving {_entityName} changes";

            throw new InternalErrorException(message);
        }

        protected async Task<BaseApiResponse<TSingleDto>> DeleteBaseAsync(TKey key)
        {
            var entity = await TryGetExistentEntity(key);

            await _repository.DeleteAsync(entity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
            {
                var response = _mapper.Map<TSingleDto>(entity);
                return new BaseApiResponse<TSingleDto>(response);
            }

            var message = $"Problem while deleting {_entityName} changes";

            throw new InternalErrorException(message);
        }

        protected async Task<TEntity> TryGetExistentEntity(TKey key)
        {
            var existentEntity = await _repository.GetByIdAsync(key);

            if (existentEntity == null)
            {
                var message = $"Entity: {_entityName} with key: {key} does not exist";
                throw new NotFoundException(message);
            }

            return existentEntity;
        }

        protected async Task<TEntity> TryGetExistentEntity(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _repository.FindSingleAsync(expression);

            if (entity == null)
            {
                var message = $"Entity: {_entityName} with expression: {expression.Name} does not exist";
                throw new NotFoundException(message);
            }

            return entity;
        }
    }
}