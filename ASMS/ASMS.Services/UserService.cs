using ASMS.CrossCutting.Constants;
using ASMS.CrossCutting.Settings;
using ASMS.Domain.Entities;
using ASMS.DTOs.Auth;
using ASMS.DTOs.Users;
using ASMS.Infrastructure;
using ASMS.Infrastructure.Exceptions;
using ASMS.Infrastructure.Security;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASMS.Services
{
    public class UserService : ServiceBase<User, long, UserBasicDto, UserListDto>, IUserService
    {
        private readonly AuthSettings _authSettings;

        public UserService(IUnitOfWork uow,
                           IMapper mapper,
                           IOptions<AuthSettings> options)
            : base(uow, nameof(User), mapper)
        {
            _authSettings = options.Value;
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
                        RoleId = role,
                    });
                }
            };

            return await CreateBaseAsync(dto, action);
        }

        public async Task<BaseApiResponse<AuthResponseDto>> LoginAsync(AuthLoginDto dto)
        {
            IIncludableQueryable<User, object> includeQuery(IQueryable<User> x) => x.Include(x => x.UserRoles)
                                                                                    .ThenInclude(x => x.Role);

            var entity = await _repository.FindSingleAsync(x => x.UserName == dto.UserName, includeQuery);

            if (ValidatePassword(entity, dto.Password))
            {
                var response = _mapper.Map<AuthResponseDto>(entity);

                GenerateToken(entity, response);

                return new BaseApiResponse<AuthResponseDto>(response);
            }

            throw new BadRequestException("User or Password incorrect");
        }

        private void GenerateToken(User user, AuthResponseDto dto)
        {
            var key = Encoding.ASCII.GetBytes(_authSettings.SecretKey);

            var claims = new List<Claim>
            {
                new Claim(ASMSConfiguration.IdClaim, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
            };

            var rolesClaim = user.UserRoles.Select(x => new Claim(ClaimTypes.Role, x.Role.Name));
            claims.AddRange(rolesClaim);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(_authSettings.TokenDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            dto.Token = tokenHandler.WriteToken(createdToken);
        }

        private bool ValidatePassword(User? user, string requestPassword) => user != null && EncryptExtensions.VerifyPass(requestPassword, user.Password);
    }
}