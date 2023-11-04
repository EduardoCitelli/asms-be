using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMembers;
using ASMS.DTOs.Shared;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class InstituteMemberConfig
    {
        internal static ASMSProfile AddInstituteMemberConfig(this ASMSProfile profile)
        {
            #region MapToEntity
            profile.CreateMap<InstituteMemberCreateDto, InstituteMember>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber))
                   .AfterMap((dto, entity) => entity.User.UserRoles = new List<UserRole> { new UserRole { RoleId = RoleTypeEnum.Member } });

            profile.CreateMap<InstituteMemberUpdateDto, InstituteMember>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber));
            #endregion

            #region MapFromEntity
            profile.CreateMap<InstituteMember, InstituteMemberSingleDto>()
                   .ForMember(dto => dto.PersonalInfo, config => config.MapFrom(entity => entity));

            profile.CreateMap<InstituteMember, PersonalInfoDto>();

            profile.CreateMap<InstituteMember, InstituteMemberListDto>()
                   .ForMember(dto => dto.FullName, conf => conf.MapFrom(entity => $"{entity.User.LastName}, {entity.User.FirstName}"));
            #endregion

            return profile;
        }
    }
}
