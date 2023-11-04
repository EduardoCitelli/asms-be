using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.InstituteMembers;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class InstituteMemberService : ServiceBase<InstituteMember, long, InstituteMemberSingleDto, InstituteMemberListDto>, IInstituteMemberService
    {
        public InstituteMemberService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(InstituteMember), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<InstituteMemberListDto>>> GetListAsync(int pageNumber = 1,
                                                                                           int pageSize = 10,
                                                                                           Expression<Func<InstituteMember, bool>>? query = null,
                                                                                           Func<IQueryable<InstituteMember>, IIncludableQueryable<InstituteMember, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id, x => x.User);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> CreateAsync(InstituteMemberCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> UpdateAsync(InstituteMemberUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id, null, x => x.User);
        }

        public async Task<BaseApiResponse<InstituteMemberSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}