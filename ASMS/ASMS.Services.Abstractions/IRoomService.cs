using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Rooms;
using ASMS.DTOs.Shared;
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
        Task<BaseApiResponse<PagedList<RoomListDto>>> GetListAsync(int pageNumber = 1, int pageSize = 10, Func<IQueryable<Room>, IIncludableQueryable<Room, object>>? include = null);
        Task<BaseApiResponse<PagedList<RoomListDto>>> GetListAsync(Expression<Func<Room, bool>> query, int pageNumber = 1, int pageSize = 10, Func<IQueryable<Room>, IIncludableQueryable<Room, object>>? include = null);
        Task<BaseApiResponse<RoomSingleDto>> GetOneAsync(long id);
        Task<BaseApiResponse<IEnumerable<ComboDto<long>>>> GetComboAsync();
        Task ValidateExistingAsync(long key);
    }
}