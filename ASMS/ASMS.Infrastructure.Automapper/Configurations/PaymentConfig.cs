using ASMS.Domain.Entities;
using ASMS.DTOs.Payments;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class PaymentConfig
    {
        internal static ASMSProfile AddPaymentConfig(this ASMSProfile profile)
        {
            #region Map to entity
            profile.CreateMap<PaymentCreateDto, Payment>();
            profile.CreateMap<PaymentUpdateDto, Payment>();
            #endregion

            #region Map from entity
            profile.CreateMap<Payment, PaymentSingleDto>()
                   .ForMember(dto => dto.PayBy, config => config.MapFrom(entity => $"{entity.MembershipPayment.InstituteMember.User.LastName}, {entity.MembershipPayment.InstituteMember.User.FirstName}"))
                   .ForMember(dto => dto.MembershipName, config => config.MapFrom(entity => entity.MembershipPayment.Membership.Name))
                   .ForMember(dto => dto.MembershipTypeName, config => config.MapFrom(entity => entity.MembershipPayment.Membership.MembershipType.Name));

            profile.CreateMap<Payment, PaymentDto>()
                   .ReverseMap();

            profile.CreateMap<Payment, PaymentListDto>()
                   .ForMember(dto => dto.PayBy, config => config.MapFrom(entity => $"{entity.MembershipPayment.InstituteMember.User.LastName}, {entity.MembershipPayment.InstituteMember.User.FirstName}"));
            #endregion

            return profile;
        }
    }
}