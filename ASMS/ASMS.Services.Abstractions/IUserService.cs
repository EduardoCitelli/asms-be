using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Auth;
using ASMS.DTOs.MyUser;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IUserService
    {
        Task<BaseApiResponse<PagedList<UserListDto>>> GetListAsync(int pageNumber = 1,
                                                                   int pageSize = 10,
                                                                   Expression<Func<User, bool>>? query = null,
                                                                   Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null);

        Task<BaseApiResponse<UserBasicDto>> GetOneAsync(long id);

        Task<BaseApiResponse<UserBasicDto>> CreateUser(UserCreateDto dto);

        Task<BaseApiResponse<AuthResponseDto>> LoginAsync(AuthLoginDto dto);

        Task<BaseApiResponse<bool>> UpdateMyPassword(UpdateMyPasswordDto dto, string userName);

        Task<BaseApiResponse<UserBasicDto>> UpdateMyUser(UpdateMyUserDto dto, long id);

        Task ValidateExistentInfo(string userName, string email);

        Task<BaseApiResponse<bool>> BlockUnblockUser(long id, bool isBlockRequest);

        Task<BaseApiResponse<IEnumerable<RoleTypeEnum>>> GetUserRoles(long userId);
    }
}