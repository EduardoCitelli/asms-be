using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.MembershipTypes;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class MembershipTypeService : ServiceBase<MembershipType, long, MembershipTypeSingleDto, MembershipTypeListDto>, IMembershipTypeService
    {
        public MembershipTypeService(IUnitOfWork uow, IMapper mapper, IInstituteIdService instituteIdService)
            : base(uow, nameof(MembershipType), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<MembershipTypeListDto>>> GetListAsync(int pageNumber = 1,
                                                                                          int pageSize = 10,
                                                                                          Expression<Func<MembershipType, bool>>? query = null,
                                                                                          Func<IQueryable<MembershipType>, IIncludableQueryable<MembershipType, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> GetOneAsync(long id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> CreateAsync(MembershipTypeCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> UpdateAsync(MembershipTypeUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id);
        }

        public async Task<BaseApiResponse<MembershipTypeSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}