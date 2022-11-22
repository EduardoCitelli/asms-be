using ASMS.Command.Plans.Commands;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Services;
using MediatR;

namespace ASMS.Command.Plans.Handlers
{
    public class PlanCreateHandler : IRequestHandler<PlanCreateCommand, BaseApiResponse<PlanSingleDto>>
    {
        private readonly IPlanService _planService;

        public PlanCreateHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<BaseApiResponse<PlanSingleDto>> Handle(PlanCreateCommand request, CancellationToken cancellationToken)
        {
            var nameAlreadyExist = await _planService.ExistEntityAsync(x => x.Name.ToLower() == request.Name.ToLower());

            return nameAlreadyExist ? throw new BadRequestException("Plan name already exist") : await _planService.CreateAsync(request);
        }
    }
}
