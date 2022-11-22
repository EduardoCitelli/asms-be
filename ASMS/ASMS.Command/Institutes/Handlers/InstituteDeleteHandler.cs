using ASMS.Command.Institutes.Commands;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Institutes.Handlers
{
    public class InstituteDeleteHandler : IRequestHandler<InstituteDeleteCommand, BaseApiResponse<InstituteSingleDto>>
    {
        private readonly IInstituteService _instituteService;

        public InstituteDeleteHandler(IInstituteService instituteService)
        {
            _instituteService = instituteService;
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Handle(InstituteDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _instituteService.Delete(request.Id);
        }
    }
}
