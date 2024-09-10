using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstitutePlan;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Services
{
    public class InstitutePlanService : IInstitutePlanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<InstitutePlan, long> _repository;
        private readonly IInstituteIdService _instituteIdService;

        public InstitutePlanService(IUnitOfWork unitOfWork,
                                    IMapper mapper,
                                    IInstituteIdService instituteIdService)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _repository = _uow.GetRepository<InstitutePlan, long>();
            _instituteIdService = instituteIdService;
        }

        public async Task<BaseApiResponse<bool>> SetNewPlanToInstituteAsync(InstitutePlanCreateDto request)
        {
            var entity = _mapper.Map<InstitutePlan>(request);
            await _repository.AddAsync(entity);

            await GetAndFinishOldPlan(request);

            await GetInstituteAndSetAsEnable(request);

            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<bool>(true);

            var message = $"Problem while saving instute plan changes";

            throw new InternalErrorException(message);
        }

        public async Task<InstitutePlan> GetActivePlan(Func<IQueryable<InstitutePlan>, IIncludableQueryable<InstitutePlan, object>>? include = null)
        {
            var plan = await _repository.FindSingleAsync(x => x.IsCurrentPlan && x.InstituteId == _instituteIdService.InstituteId, include);

            return plan ?? throw new BadRequestException("The institute doesn't have an active plan");
        }

        private async Task GetAndFinishOldPlan(InstitutePlanCreateDto request)
        {
            var existingPlan = await _repository.FindSingleAsync(x => x.InstituteId == request.InstituteId && x.IsCurrentPlan);

            if (existingPlan != null)
                await FinishOldPlan(request, existingPlan);
        }

        private async Task FinishOldPlan(InstitutePlanCreateDto request, InstitutePlan existingPlan)
        {
            ValidateAlreadySetPlan(request, existingPlan);

            existingPlan.IsCurrentPlan = false;
            existingPlan.FinishDate = DateOnly.FromDateTime(DateTime.UtcNow);

            await _repository.UpdateAsync(existingPlan);
        }

        private static void ValidateAlreadySetPlan(InstitutePlanCreateDto request, InstitutePlan existingPlan)
        {
            if (existingPlan.PlanId == request.PlanId)
                throw new BadRequestException("The plan you're trying to set is the same you already have for this institute.");
        }

        private async Task GetInstituteAndSetAsEnable(InstitutePlanCreateDto request)
        {
            var instituteRepository = _uow.GetRepository<Institute, long>();

            var instituteEntity = await instituteRepository.FindSingleAsync(x => x.Id == request.InstituteId && !x.IsEnabled);

            if (instituteEntity != null)
                await SetInstituteAsEnable(instituteRepository, instituteEntity);
        }

        private static async Task SetInstituteAsEnable(IRepository<Institute, long> instituteRepository, Institute instituteEntity)
        {
            instituteEntity.IsEnabled = true;
            await instituteRepository.UpdateAsync(instituteEntity);
        }
    }
}