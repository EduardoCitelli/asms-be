using ASMS.Command.InstitutePlan.Commands;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.InstitutePlan.Handlers
{
    public class SetNewInstitutePlanHandler : IRequestHandler<SetNewInstitutePlanCommand, BaseApiResponse<bool>>
    {
        private readonly IInstitutePlanService _service;

        public SetNewInstitutePlanHandler(IInstitutePlanService service)
        {
            _service = service;
        }

        public async Task<BaseApiResponse<bool>> Handle(SetNewInstitutePlanCommand request, CancellationToken cancellationToken)
        {
            return await _service.SetNewPlanToInstituteAsync(request);
        }
    }
}
