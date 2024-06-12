using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMemberMemberships;
using ASMS.DTOs.Payments;
using ASMS.Infrastructure.Automapper.Converters;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class InstituteMemberMembershipConfig
    {
        internal static ASMSProfile AddInstituteMemberMembershipConfig(this ASMSProfile profile)
        {
            #region Map to entity
            profile.CreateMap<InstituteMemberMembershipCreateDto, InstituteMemberMembership>()
                   .ForMember(x => x.IsActiveMembership, config => config.MapFrom(dto => dto.Payment != null))
                   .ForMember(x => x.LastPaymentDate, config => config.MapFrom(dto => dto.Payment != null ? DateTime.UtcNow : (DateTime?)null))
                   .ForMember(x => x.Payments, config => config.MapFrom(dto => dto.Payment));

            profile.CreateMap<PaymentDto, ICollection<Payment>>()
                   .ConvertUsing<SingleObjectToListConverter<PaymentDto, Payment>>();
            #endregion

            #region Map from entity

            #endregion

            return profile;
        }
    }
}