﻿using ASMS.Domain.Entities;
using ASMS.DTOs.Coaches;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class CoachConfig
    {
        internal static ASMSProfile AddCoachConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<CoachCreateDto, Coach>();
            profile.CreateMap<CoachUpdateDto, Coach>();
            #endregion

            #region Map From Entity
            profile.CreateMap<Coach, CoachSingleDto>();
            profile.CreateMap<Coach, CoachListDto>()
                   .ForMember(dto => dto.FullName, conf => conf.MapFrom(entity => $"{entity.User.LastName}, {entity.User.FirstName}"));
            #endregion

            return profile;
        }
    }
}