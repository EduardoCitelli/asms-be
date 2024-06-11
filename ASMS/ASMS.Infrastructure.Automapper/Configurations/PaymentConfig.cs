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
            profile.CreateMap<Payment, PaymentSingleDto>();
            profile.CreateMap<Payment, PaymentDto>();
            profile.CreateMap<Payment, PaymentListDto>();
            #endregion

            return profile;
        }
    }
}