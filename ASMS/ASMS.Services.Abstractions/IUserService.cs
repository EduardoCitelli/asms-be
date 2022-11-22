using ASMS.DTOs.Auth;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IUserService
    {
        Task<BaseApiResponse<UserBasicDto>> CreateUser(UserCreateDto dto);

        Task<BaseApiResponse<AuthResponseDto>> LoginAsync(AuthLoginDto dto);

        Task ValidateExistentInfo(string userName, string email);
    }
}