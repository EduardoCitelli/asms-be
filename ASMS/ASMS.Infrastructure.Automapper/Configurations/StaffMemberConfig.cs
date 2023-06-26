using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.Shared;
using ASMS.DTOs.StaffMembers;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class StaffMemberConfig
    {
        internal static ASMSProfile AddStaffMemberConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<StaffMemberCreateDto, StaffMember>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber))
                   .AfterMap((dto, entity) => entity.User.UserRoles = new List<UserRole> { new UserRole { RoleId = RoleTypeEnum.StaffMember } });

            profile.CreateMap<StaffMemberUpdateDto, StaffMember>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber));
            #endregion

            #region Map From Entity
            profile.CreateMap<StaffMember, StaffMemberSingleDto>()
                   .ForMember(dto => dto.PersonalInfo, config => config.MapFrom(entity => entity));

            profile.CreateMap<StaffMember, PersonalInfoDto>();

            profile.CreateMap<StaffMember, StaffMemberListDto>()
                   .ForMember(dto => dto.FullName, conf => conf.MapFrom(entity => $"{entity.User.LastName}, {entity.User.FirstName}"));
            #endregion

            return profile;
        }
    }
}