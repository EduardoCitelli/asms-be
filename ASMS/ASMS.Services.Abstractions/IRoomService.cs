using ASMS.Domain.Entities;
using ASMS.DTOs.Rooms;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IRoomService
    {
        Task<BaseApiResponse<RoomSingleDto>> CreateAsync(RoomCreateDto dto);
        Task<BaseApiResponse<RoomSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<RoomSingleDto>> UpdateAsync(RoomUpdateDto dto);
        Task<bool> AnyAsync(Expression<Func<Room, bool>> expression,
                            Func<IQueryable<Room>, IIncludableQueryable<Room, object>>? include = null);
    }
}