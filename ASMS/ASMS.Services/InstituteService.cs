using ASMS.CrossCutting.Enums;
using ASMS.Domain.Entities;
using ASMS.DTOs.Institutes;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class InstituteService : ServiceBase<Institute, long, InstituteSingleDto, InstituteListDto>, IInstituteService
    {
        public InstituteService(IUnitOfWork uow, IMapper mapper)
            : base(uow, nameof(Institute), mapper)
        {
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Create(InstituteCreateDto dto)
        {
            return await CreateBaseAsync(dto);
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Update(InstituteUpdateDto dto)
        {
            return await UpdateBaseAsync(dto, dto.Id);
        }

        public async Task<BaseApiResponse<InstituteSingleDto>> Delete(long id)
        {
            return await DeleteBaseAsync(id);
        }

        public async Task<bool> Any(Expression<Func<Institute, bool>> query,
                                    Func<IQueryable<Institute>, IIncludableQueryable<Institute, object>>? include = null)
        {
            return await ExistBaseAsync(query, include);
        }
    }
}
