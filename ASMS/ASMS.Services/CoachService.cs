using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class CoachService : ServiceBase<Coach, long, CoachSingleDto, CoachListDto>, ICoachService
    {
        public CoachService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Coach), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<CoachListDto>>> GetListAsync(int pageNumber = 1,
                                                                                 int pageSize = 10,
                                                                                 Expression<Func<Coach, bool>>? query = null,
                                                                                 Func<IQueryable<Coach>, IIncludableQueryable<Coach, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<CoachSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id, x => x.User);
        }

        public async Task<BaseApiResponse<CoachSingleDto>> CreateAsync(CoachCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<CoachSingleDto>> UpdateAsync(CoachUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id, null, x => x.User);
        }

        public async Task<BaseApiResponse<CoachSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}