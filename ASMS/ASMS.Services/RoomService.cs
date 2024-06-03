using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class RoomService : ServiceBase<Room, long, RoomSingleDto, RoomListDto>, IRoomService
    {
        public RoomService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Room), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<RoomListDto>>> GetListAsync(int pageNumber = 1,
                                                                                int pageSize = 10,
                                                                                Func<IQueryable<Room>, IIncludableQueryable<Room, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, null, include);
        }

        public async Task<BaseApiResponse<PagedList<RoomListDto>>> GetListAsync(Expression<Func<Room, bool>> query,
                                                                                int pageNumber = 1,
                                                                                int pageSize = 10,
                                                                                Func<IQueryable<Room>, IIncludableQueryable<Room, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<RoomSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<BaseApiResponse<RoomSingleDto>> CreateAsync(RoomCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<RoomSingleDto>> UpdateAsync(RoomUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id);
        }

        public async Task<BaseApiResponse<RoomSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }

        public async Task<bool> AnyAsync(Expression<Func<Room, bool>> expression,
                                         Func<IQueryable<Room>, IIncludableQueryable<Room, object>>? include = null)
        {
            return await ExistBaseAsync(expression, include);
        }
    }
}