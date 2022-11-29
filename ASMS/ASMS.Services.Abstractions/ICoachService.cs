using ASMS.DTOs.Coaches;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface ICoachService
    {
        Task<BaseApiResponse<CoachSingleDto>> CreateAsync(CoachCreateDto dto);
        Task<BaseApiResponse<CoachSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<CoachSingleDto>> UpdateAsync(CoachUpdateDto dto);
    }
}