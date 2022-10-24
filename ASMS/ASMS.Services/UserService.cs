using ASMS.Domain.Entities;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;

namespace ASMS.Services
{
    public class UserService : ServiceBase<User, long, UserBasicDto, UserListDto>, IUserService
    {
        public UserService(IUnitOfWork uow, IMapper mapper)
            : base(uow, nameof(User), mapper)
        {
        }

        public async Task<BaseApiResponse<bool>> ExistUserName(string userName)
        {
            var result = await _repository.FindExistAsync(x => x.UserName == userName);
            return new BaseApiResponse<bool>(result);
        }

        public async Task<BaseApiResponse<bool>> ExistEmail(string email)
        {
            var result = await _repository.FindExistAsync(x => x.Email == email.ToLower());
            return new BaseApiResponse<bool>(result);
        }

        public async Task<BaseApiResponse<UserBasicDto>> CreateUser(UserCreateDto dto)
        {
            Action<User> action = x =>
            {
                foreach (var role in dto.Roles)
                {
                    x.UserRoles.Add(new UserRole
                    {
                        RoleId = role
                    });
                }
            };

            return await CreateBaseAsync(dto, action);
        }
    }
}