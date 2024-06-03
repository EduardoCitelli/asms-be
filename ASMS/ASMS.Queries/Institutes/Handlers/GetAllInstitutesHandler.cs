using ASMS.CrossCutting.Utils;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Queries.Institutes.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Queries.Institutes.Handlers
{
    public class GetAllInstitutesHandler : IRequestHandler<GetAllInstitutes, BaseApiResponse<PagedList<InstituteListDto>>>
    {
        private readonly IInstituteService _instituteService;

        public GetAllInstitutesHandler(IInstituteService instituteService)
        {
            _instituteService = instituteService;
        }

        public async Task<BaseApiResponse<PagedList<InstituteListDto>>> Handle(GetAllInstitutes request, CancellationToken cancellationToken)
        {
            return await _instituteService.GetListAsync(request.Page, request.Size, include: x => x.Include(x => x.InstitutePlans));
        }
    }
}
