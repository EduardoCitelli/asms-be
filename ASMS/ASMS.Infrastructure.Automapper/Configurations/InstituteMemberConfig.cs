using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMembers;
using ASMS.DTOs.Shared;
using System.Linq.Expressions;

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
                   .AfterMap((dto, entity) => entity.User.UserRoles = new List<UserRole> { new() { RoleId = RoleTypeEnum.Member } });

            profile.CreateMap<InstituteMemberUpdateDto, InstituteMember>()
                   .ForMember(entity => entity.BirthDate, config => config.MapFrom(dto => dto.PersonalInfo.BirthDate))
                   .ForMember(entity => entity.Phone, config => config.MapFrom(dto => dto.PersonalInfo.Phone))
                   .ForMember(entity => entity.AddressStreet, config => config.MapFrom(dto => dto.PersonalInfo.AddressStreet))
                   .ForMember(entity => entity.AddressNumber, config => config.MapFrom(dto => dto.PersonalInfo.AddressNumber))
                   .ForMember(entity => entity.AddressExtraInfo, config => config.MapFrom(dto => dto.PersonalInfo.AddressExtraInfo))
                   .ForMember(entity => entity.IdentificationNumber, config => config.MapFrom(dto => dto.PersonalInfo.IdentificationNumber));

            profile.CreateMap<UpdateStatusInstituteMemberDto, InstituteMember>();
            #endregion

            #region MapFromEntity
            profile.CreateMap<InstituteMember, InstituteMemberSingleDto>()
                   .ForMember(dto => dto.PersonalInfo, config => config.MapFrom(entity => entity));

            profile.CreateMap<InstituteMember, PersonalInfoDto>();

            profile.CreateMap<InstituteMember, ComboDto<long>>()
                   .ForMember(dto => dto.Name, config => config.MapFrom(entity => $"{entity.User.LastName}, {entity.User.FirstName}"));

            profile.CreateMap<InstituteMember, InstituteMemberListDto>()
                   .ForMember(dto => dto.FullName, conf => conf.MapFrom(entity => $"{entity.User.LastName}, {entity.User.FirstName}"))
                   .ForMember(dto => dto.HasMembership, conf => conf.MapFrom(entity => entity.Memberships.Any(x => x.IsActiveMembership)))
                   .ForMember(dto => dto.RemainingPayment, conf => conf.MapFrom(GetRemainingPaymentQuery()))
                   .ForMember(dto => dto.MembershipPrice, conf => conf.MapFrom(GetMembershipPriceQuery()))
                   .ForMember(dto => dto.NeedToPayMembership, conf => conf.MapFrom(GetNeedToPayQuery()));

            #endregion

            return profile;
        }

        private static Expression<Func<InstituteMember, bool?>> GetNeedToPayQuery()
        {
            return entity => !entity.Memberships.Any(x => x.IsActiveMembership) || entity.Memberships.SingleOrDefault(x => x.IsActiveMembership).NeedToPay;
        }

        private static Expression<Func<InstituteMember, decimal?>> GetRemainingPaymentQuery()
        {
            return entity => entity.Memberships.SingleOrDefault(x => x.IsActiveMembership) == null ?
            0 :
            entity.Memberships.SingleOrDefault(x => x.IsActiveMembership).NeedToPay ?
            entity.Memberships.SingleOrDefault(x => x.IsActiveMembership).Membership.Price :
            entity.Memberships.SingleOrDefault(x => x.IsActiveMembership).RemainingPayment;
        }

        private static Expression<Func<InstituteMember, decimal?>> GetMembershipPriceQuery()
        {
            return entity => entity.Memberships.SingleOrDefault(x => x.IsActiveMembership) == null ? 0 : entity.Memberships.SingleOrDefault(x => x.IsActiveMembership).Membership.Price;
        }
    }
}