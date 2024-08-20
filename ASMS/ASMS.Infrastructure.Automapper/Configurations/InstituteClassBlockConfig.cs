using ASMS.CrossCutting.Enums;
using ASMS.CrossCutting.Extensions;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClassBlocks;
using ASMS.DTOs.InstituteClasses;
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
                   .AfterMap((dto, entity) => entity.ClassStatus = ClassStatus.Pending);

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
            profile.CreateMap<InstituteClassBlock, InstituteClassBlockListDto>()
                   .ForMember(dto => dto.PrincipalCoachName, config => config.MapFrom(entity => $"{entity.PrincipalCoach.User.LastName}, {entity.PrincipalCoach.User.FirstName}"))
                   .ForMember(dto => dto.ActivityId, config => config.MapFrom(entity => entity.Header.ActivityId))
                   .ForMember(dto => dto.Description, config => config.MapFrom(entity => entity.Header.Description));

            profile.CreateMap<InstituteClassBlock, InstituteClassBlockSingleDto>()
                   .ForMember(dto => dto.PrincipalCoachName, config => config.MapFrom(entity => $"{entity.PrincipalCoach.User.LastName}, {entity.PrincipalCoach.User.FirstName}"))
                   .ForMember(dto => dto.Description, config => config.MapFrom(entity => entity.Header.Description))
                   .ForMember(dto => dto.ActivityId, config => config.MapFrom(entity => entity.Header.ActivityId))
                   .ForMember(dto => dto.ActivityName, config => config.MapFrom(entity => entity.Header.Activity.Name))
                   .ForMember(dto => dto.RoomName, config => config.MapFrom(entity => entity.Room.Name))
                   .ForMember(dto => dto.AuxCoachName, config => config.MapFrom(entity => entity.AuxCoach == null ? "" : $"{entity.AuxCoach.User.LastName}, {entity.AuxCoach.User.FirstName}"));

            profile.CreateMap<InstituteClassBlock, InstituteClassBlockCalendarDto>()
                   .ForMember(dto => dto.PrincipalCoachName, config => config.MapFrom(entity => $"{entity.PrincipalCoach.User.LastName}, {entity.PrincipalCoach.User.FirstName}"))
                   .ForMember(dto => dto.ActivityId, config => config.MapFrom(entity => entity.Header.ActivityId))
                   .ForMember(dto => dto.Description, config => config.MapFrom(entity => entity.Header.Description));
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