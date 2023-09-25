using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Queries.Institutes.Requests;
using ASMS.Services.Abstractions;
using MediatR;

namespace ASMS.Queries.Institutes.Handlers
{
    public class GetInstituteByIdHandler : IRequestHandler<GetInstituteById, BaseApiResponse<InstituteSingleDto>>
    {
        private readonly IInstituteService _instituteService;

        public GetInstituteByIdHandler(IInstituteService instituteService)
        {
            _instituteService = instituteService;
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Handle(GetInstituteById request, CancellationToken cancellationToken)
        {
            return await _instituteService.GetOneAsync(request.Id);
        }
    }
}
