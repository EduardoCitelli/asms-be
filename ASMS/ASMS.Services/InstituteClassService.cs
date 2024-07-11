using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;

namespace ASMS.Services
{
    public class InstituteClassService : IInstituteClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IRepository<InstituteClass, long> _repository;

        public InstituteClassService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _repository = _uow.GetRepository<InstituteClass, long>();
        }

        public async Task<BaseApiResponse<bool>> CreateAsync(InstituteClassCreateDto dto, 
                                                             Action<InstituteClass>? actionBeforeSave = null)
        {
            var newEntity = _mapper.Map<InstituteClass>(dto);

            actionBeforeSave?.Invoke(newEntity);

            await _repository.AddAsync(newEntity);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<bool>(success);

            var message = $"Problem while saving Institute class changes";

            throw new InternalErrorException(message);
        }
    }
}