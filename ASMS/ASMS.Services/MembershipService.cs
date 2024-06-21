using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Memberships;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class MembershipService : ServiceBase<Membership, long, MembershipSingleDto, MembershipListDto>, IMembershipService
    {
        public MembershipService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(Membership), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<MembershipListDto>>> GetListAsync(int pageNumber = 1,
                                                                                      int pageSize = 10,
                                                                                      Expression<Func<Membership, bool>>? query = null,
                                                                                      Func<IQueryable<Membership>, IIncludableQueryable<Membership, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<MembershipSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<BaseApiResponse<IEnumerable<MembershipComboDto>>> GetForComboAsync()
        {
            return await GetForComboBaseAsync<MembershipComboDto>();
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