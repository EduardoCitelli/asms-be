using ASMS.Domain.Entities;
using ASMS.DTOs.MembershipTypes;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class MembershipTypeConfig
    {
        internal static ASMSProfile AddMembershipTypeConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<MembershipTypeCreateDto, MembershipType>();
            profile.CreateMap<MembershipTypeUpdateDto, MembershipType>();
            #endregion

            #region Map From Entity
            profile.CreateMap<MembershipType, MembershipTypeSingleDto>();
            profile.CreateMap<MembershipType, MembershipTypeListDto>();
            #endregion

            return profile;
        }
    }
}