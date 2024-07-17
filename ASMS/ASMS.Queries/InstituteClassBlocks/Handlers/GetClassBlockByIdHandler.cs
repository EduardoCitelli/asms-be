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
    public class GetClassBlockByIdHandler : IRequestHandler<GetClassBlockById, BaseApiResponse<InstituteClassBlockSingleDto>>
    {
        private readonly IInstituteClassBlockService _instituteClassBlockService;

        public GetClassBlockByIdHandler(IInstituteClassBlockService instituteClassBlockService)
        {
            _instituteClassBlockService = instituteClassBlockService;
        }

        public async Task<BaseApiResponse<InstituteClassBlockSingleDto>> Handle(GetClassBlockById request, CancellationToken cancellationToken)
        {
            return await _instituteClassBlockService.GetOneDtoAsync(request.Id, IncludeDependencies());
        }

        private static Func<IQueryable<InstituteClassBlock>, IIncludableQueryable<InstituteClassBlock, object?>> IncludeDependencies()
        {
            return x => x.Include(x => x.Header)
                            .ThenInclude(x => x.Activity)
                         .Include(x => x.PrincipalCoach)
                            .ThenInclude(x => x.User)
                         .Include(x => x.Room)
                         .Include(x => x.AuxCoach)
                            .ThenInclude(x => x.User);
        }
    }
}