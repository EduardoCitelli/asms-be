using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.Coaches;
using ASMS.DTOs.Shared;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class CoachConfig
    {
        internal static ASMSProfile AddCoachConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<CoachCreateDto, Coach>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber))
                   .AfterMap((dto, entity) => entity.User.UserRoles = new List<UserRole> { new UserRole { RoleId = RoleTypeEnum.Coach } });

            profile.CreateMap<CoachUpdateDto, Coach>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber));
            #endregion

            #region Map From Entity
            profile.CreateMap<Coach, CoachSingleDto>()
                   .ForMember(dto => dto.PersonalInfo, config => config.MapFrom(entity => entity));

            profile.CreateMap<Coach, PersonalInfoDto>();

            profile.CreateMap<Coach, CoachListDto>()
                   .ForMember(dto => dto.FullName, conf => conf.MapFrom(entity => $"{entity.User.LastName}, {entity.User.FirstName}"));
            #endregion

            return profile;
        }
    }
}
