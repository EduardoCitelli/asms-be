using ASMS.Domain.Entities;
using ASMS.DTOs.InstitutePlan;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;

namespace ASMS.Services
{
    public class InstitutePlanService : IInstitutePlanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<InstitutePlan, long> _repository;

        public InstitutePlanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _repository = _uow.GetRepository<InstitutePlan, long>();
        }

        public async Task<BaseApiResponse<bool>> SetNewPlanToInstituteAsync(InstitutePlanCreateDto request)
        {
            var entity = _mapper.Map<InstitutePlan>(request);

            var existingPlan = await _repository.FindSingleAsync(x => x.InstituteId == request.InstituteId && x.IsCurrentPlan);

            if (existingPlan != null)
            {
                if (existingPlan.PlanId == request.PlanId)
                    throw new BadRequestException("The plan you're trying to set is the same you already have for this institute.");

                existingPlan.IsCurrentPlan = false;
                existingPlan.FinishDate = DateOnly.FromDateTime(DateTime.Now);
                await _repository.UpdateAsync(existingPlan);
            }

            await _repository.AddAsync(entity);

            var instituteRepository = _uow.GetRepository<Institute, long>();
            var instituteEntity = await instituteRepository.FindSingleAsync(x => x.Id == request.InstituteId && !x.IsEnabled);

            if (instituteEntity != null)
            {
                instituteEntity.IsEnabled = true;
                await instituteRepository.UpdateAsync(instituteEntity);
            }

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<bool>(true);

            var message = $"Problem while saving instute plan changes";

            throw new InternalErrorException(message);
        }
    }
}
