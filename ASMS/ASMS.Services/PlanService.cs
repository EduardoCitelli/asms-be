﻿using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Plans;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class PlanService : ServiceBase<Plan, int, PlanSingleDto, PlanDto>, IPlanService
    {
        public PlanService(IUnitOfWork uow, IMapper mapper)
            : base(uow, nameof(Plan), mapper)
        {
        }

        public async Task<BaseApiResponse<PagedList<PlanDto>>> GetListAsync(int pageNumber = 1,
                                                                            int pageSize = 10,
                                                                            Func<IQueryable<Plan>, IIncludableQueryable<Plan, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, include);
        }

        public async Task<BaseApiResponse<PagedList<PlanDto>>> GetListQueryAsync(Expression<Func<Plan, bool>> query,
                                                                                 int pageNumber = 1,
                                                                                 int pageSize = 10,
                                                                                 Func<IQueryable<Plan>, IIncludableQueryable<Plan, object>>? include = null)
        {
            return await GetDtoPaginatedsByQueryBaseAsync(query, pageNumber, pageSize, include);
        }

        public async Task<BaseApiResponse<PlanSingleDto>> GetOneAsync(int id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<BaseApiResponse<PlanSingleDto>> CreateAsync(PlanCreateDto planCreateDto)
        {
            return await CreateBaseAsync(planCreateDto);
        }

        public async Task<BaseApiResponse<PlanSingleDto>> UpdateAsync(PlanUpdateDto planUpdateDto)
        {
            return await UpdateBaseAsync(planUpdateDto, planUpdateDto.Id);
        }

        public async Task<BaseApiResponse<PlanSingleDto>> DeleteAsync(int id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}