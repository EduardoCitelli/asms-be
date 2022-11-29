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
        public RoomService(IUnitOfWork uow, IMapper mapper)
            : base(uow, nameof(Room), mapper)
        {
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