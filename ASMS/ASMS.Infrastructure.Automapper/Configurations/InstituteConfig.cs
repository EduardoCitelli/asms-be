using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.Institutes;
using ASMS.DTOs.Shared;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class InstituteConfig
    {
        internal static ASMSProfile AddInstituteConfig(this ASMSProfile profile)
        {
            #region MapToEntity
            profile.CreateMap<InstituteCreateDto, Institute>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber))
                   .AfterMap((dto, entity) => entity.User.UserRoles = new List<UserRole> { new() { RoleId = RoleTypeEnum.Manager } });

            profile.CreateMap<InstituteUpdateDto, Institute>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber));

            #endregion

            #region MapFromEntity
            profile.CreateMap<Institute, InstituteSingleDto>()
                   .ForMember(dto => dto.PersonalInfo, config => config.MapFrom(entity => entity));

            profile.CreateMap<Institute, PersonalInfoDto>();

            profile.CreateMap<Institute, InstituteListDto>()
                    .ForMember(dto => dto.PlanId, config => config.MapFrom(entity => entity.InstitutePlans.Where(x => x.IsCurrentPlan).FirstOrDefault().PlanId));
            #endregion

            return profile;
        }


    }
}
