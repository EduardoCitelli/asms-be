using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
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

        public async Task UpdateStatusFromNewToFinished()
        {
            var response = await _repository.Find(x => x.ClassStatus == ClassStatus.New && x.StartDateTime < DateTime.UtcNow)
                                            .ToListAsync();

            if (response.Any())
            {
                foreach (var block in response)
                    block.ClassStatus = ClassStatus.Finished;

                await _repository.UpdateCollectionAsync(response);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
