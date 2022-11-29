using ASMS.Domain.Entities;
using ASMS.DTOs.StaffMembers;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class StaffMemberConfig
    {
        internal static ASMSProfile AddStaffMemberConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<StaffMemberCreateDto, StaffMember>();
            profile.CreateMap<StaffMemberUpdateDto, StaffMember>();
            #endregion

            #region Map From Entity
            profile.CreateMap<StaffMember, StaffMemberSingleDto>();
            profile.CreateMap<StaffMember, StaffMemberListDto>()
                   .ForMember(dto => dto.FullName, conf => conf.MapFrom(entity => $"{entity.User.LastName}, {entity.User.FirstName}"));
            #endregion

            return profile;
        }
    }
}