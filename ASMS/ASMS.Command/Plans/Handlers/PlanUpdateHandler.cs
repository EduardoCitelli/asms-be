using ASMS.Command.Plans.Commands;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services;
using MediatR;

namespace ASMS.Command.Plans.Handlers
{
    public class PlanUpdateHandler : IRequestHandler<PlanUpdateCommand, BaseApiResponse<PlanSingleDto>>
    {
        private readonly IPlanService _planService;

        public PlanUpdateHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<BaseApiResponse<PlanSingleDto>> Handle(PlanUpdateCommand request, CancellationToken cancellationToken)
        {
            var nameAlreadyExist = await _planService.ExistEntityAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.Id != request.Id);

            return nameAlreadyExist ? throw new BadRequestException("Plan name already exist") : await _planService.UpdateAsync(request);
        }
    }
}