﻿using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMemberMemberships;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;

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
            {
                return new BaseApiResponse<long>(entity.Id);
            }

            var message = $"Problem while saving Institute member membership changes";

            throw new InternalErrorException(message);
        }
    }
}