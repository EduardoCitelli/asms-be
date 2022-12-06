using ASMS.CrossCutting.Constants;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
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
        private readonly Dictionary<RoleTypeEnum, Func<User, long>> _roleToInstituteId = new()
        {
            {RoleTypeEnum.Manager, (user) => user.Institute!.Id },
            {RoleTypeEnum.StaffMember, (user) => user.StaffMember!.InstituteId},
            {RoleTypeEnum.Coach, (user) => user.Coach!.InstituteId},
            {RoleTypeEnum.Member, (user) => user.InstituteMember!.InstituteId},
        };

        public UserService(IUnitOfWork uow,
                           IMapper mapper,
                           IInstituteIdService instituteIdService,
                           IOptions<AuthSettings> options)
            : base(uow, nameof(User), mapper, instituteIdService)
        {
            _authSettings = options.Value;
        }

        public async Task ValidateExistentInfo(string userName, string email)
        {
            var isUserExistent = await ExistBaseAsync(x => x.UserName == userName);

            if (isUserExistent)
                throw new BadRequestException($"Username {userName} already exist");

            var isEmailExistent = await ExistBaseAsync(x => x.Email == email);

            if (isEmailExistent)
                throw new BadRequestException($"Email {email} already exist");
        }

        public async Task<BaseApiResponse<UserBasicDto>> CreateUser(UserCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<AuthResponseDto>> LoginAsync(AuthLoginDto dto)
        {
            IIncludableQueryable<User, object> includeQuery(IQueryable<User> x) => x.Include(x => x.UserRoles)
                                                                                    .ThenInclude(x => x.Role)
                                                                                    .Include(x => x.Institute!)
                                                                                    .Include(x => x.StaffMember!)
                                                                                    .Include(x => x.Coach!)
                                                                                    .Include(x => x.InstituteMember!);

            var entity = await _repository.FindSingleAsync(x => x.UserName == dto.UserName, includeQuery);

            if (ValidatePassword(entity, dto.Password))
            {
                var response = _mapper.Map<AuthResponseDto>(entity);

                GenerateToken(entity!, response);

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

            var instituteId = TryGetInstituteId(user);

            if (instituteId != null)
                claims.Add(new Claim(ASMSConfiguration.InstituteIdClaim, instituteId.ToString()!));

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

        private long? TryGetInstituteId(User user)
        {
            var rolesToGetInstituteId = user.UserRoles.Where(x => x.RoleId != RoleTypeEnum.SuperAdmin)
                                                      .OrderBy(x => x.RoleId)
                                                      .Select(x => x.RoleId)
                                                      .ToList();

            if (rolesToGetInstituteId.Any())
            {
                var role = rolesToGetInstituteId.First();
                var result = _roleToInstituteId.TryGetValue(role, out var response);
                return response!(user);
            }

            return null;
        }

        private bool ValidatePassword(User? user, string requestPassword) => user != null && EncryptExtensions.VerifyPass(requestPassword, user.Password);
    }
}