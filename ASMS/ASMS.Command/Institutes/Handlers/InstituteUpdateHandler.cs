using ASMS.Command.Institutes.Commands;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Institutes.Handlers
{
    public class InstituteUpdateHandler : IRequestHandler<InstituteUpdateCommand, BaseApiResponse<InstituteSingleDto>>
    {
        private readonly IInstituteService _instituteService;

        public InstituteUpdateHandler(IInstituteService instituteService)
        {
            _instituteService = instituteService;
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Handle(InstituteUpdateCommand request, CancellationToken cancellationToken)
        {
            await ValidateInstitute(request);
            return await _instituteService.Update(request);
        }

        private async Task<List<string>> ValidateInstitute(InstituteUpdateCommand request)
        {
            var errors = new List<string>();

            var existName = await _instituteService.Any(x => x.InstitutionName == request.InstitutionName && x.Id != x.Id);

            if (existName)
                errors.Add($"Institute Name: {request.InstitutionName} already exist");

            var existPersonalIdentification = await _instituteService.Any(x => x.IdentificationNumber == request.PersonalInfo.IdentificationNumber && x.Id != x.Id);

            if (existPersonalIdentification)
                errors.Add($"Personal identification: {request.PersonalInfo.IdentificationNumber} already exist");

            return errors;
        }
    }
}