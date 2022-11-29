using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;

namespace ASMS.Services
{
    public class StaffMemberService : ServiceBase<StaffMember, long, StaffMemberSingleDto, StaffMemberListDto>, IStaffMemberService
    {
        public StaffMemberService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(StaffMember), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> CreateAsync(StaffMemberCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> UpdateAsync(StaffMemberUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id);
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}