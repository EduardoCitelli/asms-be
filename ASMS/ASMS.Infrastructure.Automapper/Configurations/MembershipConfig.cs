using ASMS.Domain.Entities;
using ASMS.DTOs.Memberships;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class MembershipConfig
    {
        internal static ASMSProfile AddMembershipConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<MembershipCreateDto, Membership>();
            profile.CreateMap<MembershipUpdateDto, Membership>();
            #endregion

            #region Map From Entity
            profile.CreateMap<Membership, MembershipSingleDto>();
            profile.CreateMap<Membership, MembershipListDto>();
            #endregion

            return profile;
        }
    }
}