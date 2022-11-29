using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IStaffMemberService
    {
        Task<BaseApiResponse<StaffMemberSingleDto>> CreateAsync(StaffMemberCreateDto dto);
        Task<BaseApiResponse<StaffMemberSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<StaffMemberSingleDto>> UpdateAsync(StaffMemberUpdateDto dto);
    }
}