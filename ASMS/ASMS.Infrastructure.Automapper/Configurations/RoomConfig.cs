using ASMS.Domain.Entities;
using ASMS.DTOs.Rooms;
using ASMS.DTOs.Shared;

namespace ASMS.Infrastructure.Automapper.Configurations
{
    internal static class RoomConfig
    {
        internal static ASMSProfile AddRoomConfig(this ASMSProfile profile)
        {
            #region Map To Entity
            profile.CreateMap<RoomCreateDto, Room>();
            profile.CreateMap<RoomUpdateDto, Room>();
            #endregion

            #region Map From Entity
            profile.CreateMap<Room, RoomSingleDto>();
            profile.CreateMap<Room, RoomListDto>();
            profile.CreateMap<Room, ComboDto<long>>();
            #endregion

            return profile;
        }
    }
}