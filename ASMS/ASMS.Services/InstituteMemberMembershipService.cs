using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMemberMemberships;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services
{
    public class InstituteMemberMembershipService : IInstituteMemberMembershipService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<InstituteMemberMembership, long> _repository;
        private readonly IMapper _mapper;

        public InstituteMemberMembershipService(IUnitOfWork uow,
                                                IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _repository = uow.GetRepository<InstituteMemberMembership, long>();
        }

        public async Task<BaseApiResponse<long>> CreateAsync(InstituteMemberMembershipCreateDto dto, Action<InstituteMemberMembership>? actionBeforeSave = null)
        {
            var entity = _mapper.Map<InstituteMemberMembership>(dto);

            actionBeforeSave?.Invoke(entity);

            await _repository.AddAsync(entity);
            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<long>(entity.Id);

            var message = $"Problem while saving Institute member membership changes";

            throw new InternalErrorException(message);
        }

        public async Task ValidateTryToAssignSameMembership(long instituteMemberId, long membershipId)
        {
            var exist = await _repository.FindExistAsync(x => x.InstituteMemberId == instituteMemberId && x.MembershipId == membershipId && x.IsActiveMembership);

            if (exist)
                throw new BadRequestException("The membership you are trying to assign is already an active membership");
        }

        public async Task SetInactiveMembershipsWithoutSave(long instituteMemberId)
        {
            var entities = await _repository.Find(x => x.InstituteMemberId == instituteMemberId && x.IsActiveMembership)
                                            .ToListAsync();

            entities.ForEach(x => x.IsActiveMembership = false);

            await _repository.UpdateCollectionAsync(entities);
        }

        public async Task UpdateWithoutSaveAsync(InstituteMemberMembership entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<InstituteMemberMembership> GetEntityActiveByInstituteMemberAsync(long instituteMemberId, 
                                                                                           Func<IQueryable<InstituteMemberMembership>, IIncludableQueryable<InstituteMemberMembership, object>>? include = null)
        {
            var response = await _repository.FindSingleAsync(x => x.InstituteMemberId == instituteMemberId, include, x => x.StartDate, true);

            return response ?? throw new NotFoundException($"Membership for user with id:{instituteMemberId} not found");
        }
    }
}