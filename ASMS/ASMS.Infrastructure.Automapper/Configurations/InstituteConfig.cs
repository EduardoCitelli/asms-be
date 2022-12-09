using ASMS.Command.Institutes.Commands;
using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.Institutes;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class InstituteConfig
    {
        internal static ASMSProfile AddInstituteConfig(this ASMSProfile profile)
        {
            #region MapToEntity
            profile.CreateMap<InstituteCreateCommand, Institute>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber))
                   .AfterMap((dto, entity) => entity.User.UserRoles = new List<UserRole> { new UserRole { RoleId = RoleTypeEnum.Manager } });

            #endregion

            #region MapFromEntity
            profile.CreateMap<Institute, InstituteSingleDto>();
            #endregion

            return profile;
        }


    }
}
