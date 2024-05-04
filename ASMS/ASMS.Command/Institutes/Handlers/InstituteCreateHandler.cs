using ASMS.Command.Institutes.Commands;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Infrastructure.Security;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Command.Institutes.Handlers
{
    public class InstituteCreateHandler : IRequestHandler<InstituteCreateCommand, BaseApiResponse<InstituteSingleDto>>
    {
        private readonly IInstituteService _instituteService;
        private readonly IUserService _userService;

        public InstituteCreateHandler(IInstituteService instituteService, IUserService userService)
        {
            _instituteService = instituteService;
            _userService = userService;
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Handle(InstituteCreateCommand request, CancellationToken cancellationToken)
        {
            await _userService.ValidateExistentInfo(request.User.UserName, request.User.Email);
            var errors = await ValidateInstitute(request);

            request.User.Password = request.User.Password.ToHash();
            request.User.Email = request.User.Email.ToLower();

            if (errors.Any())
                throw new BadRequestException(errors);

            var response = await _instituteService.Create(request);

            await _userService.CreateAdminUserAsync(response.Content!.Id, response.Content!.InstitutionName);

            return response;
        }

        private async Task<List<string>> ValidateInstitute(InstituteCreateCommand request)
        {
            var errors = new List<string>();

            var existName = await _instituteService.Any(x => x.InstitutionName == request.InstitutionName);

            if (existName)
                errors.Add($"Institute Name: {request.InstitutionName} already exist");

            var existPersonalIdentification = await _instituteService.Any(x => x.IdentificationNumber == request.PersonalInfo.IdentificationNumber);

            if (existPersonalIdentification)
                errors.Add($"Personal identification: {request.PersonalInfo.IdentificationNumber} already exist");

            return errors;
        }
    }
}