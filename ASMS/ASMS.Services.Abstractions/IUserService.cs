using ASMS.DTOs.Auth;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IUserService
    {
        Task<BaseApiResponse<UserBasicDto>> CreateUser(UserCreateDto dto);
        Task<BaseApiResponse<bool>> ExistEmail(string email);
        Task<BaseApiResponse<bool>> ExistUserName(string userName);
        Task<BaseApiResponse<AuthResponseDto>> LoginAsync(AuthLoginDto dto);
    }
}