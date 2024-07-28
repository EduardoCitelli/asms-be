using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClassBlocks;
using ASMS.Infrastructure;
using ASMS.Queries.InstituteClassBlocks.Requests;
using ASMS.Services.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASMS.Queries.InstituteClassBlocks.Handlers
{
    public class GetAllClassBlockHandler : IRequestHandler<GetAllClassBlocks, BaseApiResponse<PagedList<InstituteClassBlockListDto>>>
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;

        public GetAllClassBlockHandler(IInstituteClassBlockService instituteClassBlockService)
        {
            _instituteClassBlockService = instituteClassBlockService;
        }

        public async Task<BaseApiResponse<PagedList<InstituteClassBlockListDto>>> Handle(GetAllClassBlocks request, CancellationToken cancellationToken)
        {
            return await _instituteClassBlockService.GetAllDtosPaginatedAsync(request, null, IncludeDependencies(), x => x.StartDateTime);
        }

        private static Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>> IncludeDependencies()
        {
            return x => x.Include(x => x.Header)
                         .Include(x => x.PrincipalCoach)
                         .ThenInclude(x => x.User);
        }
    }
}