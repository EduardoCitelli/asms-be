using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.StaffMembers;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class StaffMemberService : ServiceBase<StaffMember, long, StaffMemberSingleDto, StaffMemberListDto>, IStaffMemberService
    {
        public StaffMemberService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(StaffMember), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<StaffMemberListDto>>> GetListAsync(int pageNumber = 1,
                                                                                       int pageSize = 10,
                                                                                       Expression<Func<StaffMember, bool>>? query = null,
                                                                                       Func<IQueryable<StaffMember>, IIncludableQueryable<StaffMember, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id, x => x.Include(x => x.User));
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> CreateAsync(StaffMemberCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> UpdateAsync(StaffMemberUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id, null, x => x.Include(x => x.User));
        }

        public async Task<BaseApiResponse<StaffMemberSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}