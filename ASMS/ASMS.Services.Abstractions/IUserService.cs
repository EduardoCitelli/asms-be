using ASMS.DTOs.Auth;
using ASMS.DTOs.MyUser;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IUserService
    {
        Task<BaseApiResponse<UserBasicDto>> CreateUser(UserCreateDto dto);

        Task<BaseApiResponse<AuthResponseDto>> LoginAsync(AuthLoginDto dto);

        Task<BaseApiResponse<bool>> UpdateMyPassword(UpdateMyPasswordDto dto, string userName);

        Task<BaseApiResponse<UserBasicDto>> UpdateMyUser(UpdateMyUserDto dto, long id);

        Task ValidateExistentInfo(string userName, string email);
    }
}