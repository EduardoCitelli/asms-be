using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMemberMemberships;
using ASMS.DTOs.Payments;
using AutoMapper;

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

            profile.CreateMap<PaymentCreateDto, ICollection<Payment>>()
                   .ConvertUsing<SingleObjectToListConverter<PaymentCreateDto, Payment>>();
            #endregion

            #region Map from entity

            #endregion

            return profile;
        }
    }

    public class SingleObjectToListConverter<T, T2> : ITypeConverter<T, ICollection<T2>>
    {
        public ICollection<T2> Convert(T source, ICollection<T2> destination, ResolutionContext context)
        {
            return new List<T2>() { context.Mapper.Map<T2>(source) };
        }
    }
}
