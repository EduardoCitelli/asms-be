using ASMS.CrossCutting.Services.Abstractions;
using ASMS.Domain.Entities;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;

namespace ASMS.Services
{
    public class MembershipService : ServiceBase<Membership, long, MembershipSingleDto, MembershipListDto>, IMembershipService
    {
        public MembershipService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Membership), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> CreateAsync(MembershipCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> UpdateAsync(MembershipUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id);
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}