using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IMembershipService
    {
        Task<BaseApiResponse<MembershipSingleDto>> CreateAsync(MembershipCreateDto dto);
        Task<BaseApiResponse<MembershipSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<MembershipSingleDto>> UpdateAsync(MembershipUpdateDto dto);
    }
}