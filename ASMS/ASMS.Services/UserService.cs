using ASMS.CrossCutting.Constants;
using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Settings;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Auth;
using ASMS.DTOs.MyUser;
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
using System.Linq.Expressions;
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

        public async Task<BaseApiResponse<PagedList<UserListDto>>> GetListAsync(int pageNumber = 1,
                                                                                int pageSize = 10,
                                                                                Expression<Func<User, bool>>? query = null,
                                                                                Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<UserBasicDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<BaseApiResponse<UserBasicDto>> CreateUser(UserCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<UserBasicDto>> UpdateMyUser(UpdateMyUserDto dto, long id)
        {
            var isEmailExistent = await ExistBaseAsync(x => x.Email == dto.Email && x.Id != id);

            return isEmailExistent ? throw new BadRequestException($"Email {dto.Email} already exist") : await UpdateBaseAsync(dto, id);
        }

        public async Task<BaseApiResponse<bool>> UpdateMyPassword(UpdateMyPasswordDto dto, string userName)
        {
            var entity = await GetFullUserByUserName(userName);

            if (ValidatePassword(entity, dto.OldPassword))
            {
                entity!.Password = dto.Password.ToHash();

                await _repository.UpdateAsync(entity);

                var success = await _uow.SaveChangesAsync() > 0;

                if (success)
                    return new BaseApiResponse<bool>(true);

                var message = $"Problem while saving {_entityName} changes";
                throw new InternalErrorException(message);
            }

            throw new BadRequestException($"Wrong password");
        }

        public async Task<BaseApiResponse<AuthResponseDto>> LoginAsync(AuthLoginDto dto)
        {
            var entity = await GetFullUserByUserName(dto.UserName);

            if (ValidatePassword(entity, dto.Password))
            {
                var response = _mapper.Map<AuthResponseDto>(entity);

                GenerateToken(entity!, response);

                return new BaseApiResponse<AuthResponseDto>(response);
            }

            throw new BadRequestException("User or Password incorrect");
        }

        public async Task<BaseApiResponse<bool>> BlockUnblockUser(long id, bool isBlockRequest)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                throw new NotFoundException("User not found");

            user.IsBlocked = isBlockRequest;

            await _repository.UpdateAsync(user);
            var success = await _uow.SaveChangesAsync() > 0;

            if (success)
                return new BaseApiResponse<bool>(true);

            var message = $"Problem while saving {_entityName} changes";
            throw new InternalErrorException(message);
        }

        public async Task<BaseApiResponse<IEnumerable<RoleTypeEnum>>> GetUserRoles(long userId)
        {
            var user = await _repository.FindSingleAsync(x => x.Id == userId, x => x.Include(x => x.UserRoles));

            if (user is null)
                throw new NotFoundException("User not found");

            var roles = user.UserRoles.Select(x => x.RoleId).ToList();

            return new BaseApiResponse<IEnumerable<RoleTypeEnum>>(roles);
        }

        private async Task<User?> GetFullUserByUserName(string userName)
        {
            IIncludableQueryable<User, object> includeQuery(IQueryable<User> x) => x.Include(x => x.UserRoles)
                                                                                    .ThenInclude(x => x.Role)
                                                                                    .Include(x => x.Institute!)
                                                                                    .Include(x => x.StaffMember!)
                                                                                    .Include(x => x.Coach!)
                                                                                    .Include(x => x.InstituteMember!);

            var entity = await _repository.FindSingleAsync(x => x.UserName == userName, includeQuery);

            return entity;
        }

        private void GenerateToken(User user, AuthResponseDto dto)
        {
            var key = Encoding.ASCII.GetBytes(_authSettings.SecretKey);

            var claims = new List<Claim>
            {
                new(ASMSConfiguration.IdClaim, user.Id.ToString()),
                new(ClaimTypes.NameIdentifier, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, user.FirstName),
                new(ClaimTypes.Surname, user.LastName),
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