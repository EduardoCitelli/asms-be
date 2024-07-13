using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteClass;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class InstituteClassConfig
    {
        internal static ASMSProfile AddInstituteClassConfig(this ASMSProfile profile)
        {
            #region Map to Entity
            profile.CreateMap<InstituteClassCreateDto, InstituteClass>()
                   .ForMember(entity => entity.FinishTime, config => config.MapFrom(dto => dto.StartTime.AddMinutes(dto.MinutesDuration)))
                   .ForMember(entity => entity.DaysOfWeek, config => config.MapFrom(dto => dto.DaysOfWeek.Select(x => new InstituteClassDayOfWeek(x))))
                   .ForMember(entity => entity.Blocks, config => config.MapFrom(dto => dto));

            profile.CreateMap<InstituteClassUpdateDto, InstituteClass>()
                   .ForMember(entity => entity.FinishTime, config => config.MapFrom(dto => dto.StartTime.AddMinutes(dto.MinutesDuration)));

            #endregion

            #region Map from entity

            #endregion

            return profile;
        }
    }
}
