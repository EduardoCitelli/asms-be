using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClass;
using ASMS.Infrastructure.Automapper.Converters;
using System.Linq.Expressions;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class InstituteClassBlockConfig
    {
        internal static ASMSProfile AddInstituteClassBlockConfig(this ASMSProfile profile)
        {
            #region Map to Entity
            profile.CreateMap<InstituteClassCreateDto, ICollection<InstituteClassBlock>>()
                   .ConvertUsing<InstituteClassCreateDtoToClassBlockConverter>();

            profile.CreateMap<InstituteClassCreateDto, InstituteClassBlock>()
                   .ForMember(entity => entity.StartDateTime, config => config.MapFrom(SetNotRecurrenceDateQuery()))
                   .AfterMap((dto, entity) => entity.FinishDateTime = entity.StartDateTime.AddMinutes(dto.MinutesDuration))
                   .AfterMap((dto, entity) => entity.ClassStatus = ClassStatus.New);

            profile.CreateMap<InstituteClassUpdateDto, IEnumerable<InstituteClassBlock>>()
                   .ConvertUsing<InstituteClassUpdateDtoToClassBlockConverter>();

            profile.CreateMap<InstituteClassUpdateDto, InstituteClassBlock>()
                   .ForMember(entity => entity.StartDateTime, 
                                        config => config.MapFrom((dto, entity) => entity.StartDateTime.RemoveOffset(dto.ClientOffset)
                                                                                                      .SetTime(dto.StartTime)
                                                                                                      .AddOffset(dto.ClientOffset)))
                   .AfterMap((dto, entity) => entity.FinishDateTime = entity.StartDateTime.AddMinutes(dto.MinutesDuration));

            #endregion

            #region Map from entity

            #endregion

            return profile;
        }

        private static Expression<Func<InstituteClassCreateDto, DateTime>> SetNotRecurrenceDateQuery()
        {
            return dto => !dto.IsRecurrence && dto.NotRecurrenceDate.HasValue ?
                           dto.NotRecurrenceDate.Value.SetTime(dto.StartTime).AddOffset(dto.ClientOffset) :
                           DateTime.UtcNow;
        }
    }
}