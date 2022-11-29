using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;

namespace ASMS.Services.Abstractions
{
    public interface IMembershipTypeService
    {
        Task<BaseApiResponse<MembershipTypeSingleDto>> CreateAsync(MembershipTypeCreateDto dto);
        Task<BaseApiResponse<MembershipTypeSingleDto>> DeleteAsync(long id);
        Task<BaseApiResponse<MembershipTypeSingleDto>> UpdateAsync(MembershipTypeUpdateDto dto);
    }
}