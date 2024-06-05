using ASMS.Command.Institutes.Commands;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Institutes.Handlers
{
    public class InstituteDisableHandler : IRequestHandler<InstituteDisableCommand, BaseApiResponse<bool>>
    {
        private readonly IInstituteService _instituteService;

        public InstituteDisableHandler(IInstituteService instituteService)
        {
            _instituteService = instituteService;
        }

        public async Task<BaseApiResponse<bool>> Handle(InstituteDisableCommand request, CancellationToken cancellationToken)
        {
            return await _instituteService.SetDisableInstitute(request.InstituteId, entity =>
            {
                entity.IsEnabled = false;
                foreach (var plan in entity.InstitutePlans.Where(x => x.IsCurrentPlan))
                    plan.IsCurrentPlan = false;
            });
        }
    }
}
