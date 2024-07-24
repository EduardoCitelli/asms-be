using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.DTOs.InstituteClasses;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteClasses.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASMS.Queries.InstituteClasses.Handlers
{
    public class GetInstituteClassesHandler : IRequestHandler<GetInstituteClasses, BaseApiResponse<PagedList<InstituteClassListDto>>>
    {
        private readonly IInstituteClassService _instituteClassService;

        public GetInstituteClassesHandler(IInstituteClassService instituteClassService)
        {
            _instituteClassService = instituteClassService;
        }

        public async Task<BaseApiResponse<PagedList<InstituteClassListDto>>> Handle(GetInstituteClasses request, CancellationToken cancellationToken)
        {
            return await _instituteClassService.GetAllAsync(request, x => x.Blocks.Any(x => x.ClassStatus == ClassStatus.New), x => x.Include(x => x.Blocks));
        }
    }
}