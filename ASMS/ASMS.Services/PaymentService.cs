using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Payments;
using ASMS.DTOs.Shared;
using ASMS.Infrastructure;
using ASMS.Persistence.Abstractions;
using ASMS.Services.Abstractions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services
{
    public class PaymentService : ServiceBase<Payment, long, PaymentSingleDto, PaymentListDto>, IPaymentService
    {
        public PaymentService(IUnitOfWork uow,
                              IMapper mapper,
                              IInstituteIdService instituteIdService)
            : base(uow, nameof(Payment), mapper, instituteIdService)
        {
        }

        public async Task<BaseApiResponse<PagedList<PaymentListDto>>> GetListAsync(int pageNumber = 1,
                                                                                   int pageSize = 10,
                                                                                   Func<IQueryable<Payment>, IIncludableQueryable<Payment, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, null, include);
        }

        public async Task<BaseApiResponse<PagedList<PaymentListDto>>> GetListAsync(PagedFilterRequestDto request,
                                                                                   Expression<Func<Payment, bool>>? query = null,
                                                                                   Func<IQueryable<Payment>, IIncludableQueryable<Payment, object?>>? include = null,
                                                                                   Expression<Func<Payment, object>>? orderBy = null,
                                                                                   bool isDesc = false)
        {
            return await GetAllDtosPaginatedBaseAsync(request, query, include, orderBy, isDesc);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> GetOneAsync(long id,
                                                                         Func<IQueryable<Payment>, IIncludableQueryable<Payment, object?>>? include = null)
        {
            return await GetOneDtoBaseAsync(id, include);
        }

        public async Task<bool> ExistEntityAsync(Expression<Func<Payment, bool>> expression)
        {
            return await ExistBaseAsync(expression);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> CreateAsync(PaymentCreateDto PaymentCreateDto, Action<Payment>? actionBeforeSave = null)
        {
            return await CreateBaseAsync(PaymentCreateDto, actionBeforeSave);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> UpdateAsync(PaymentUpdateDto PaymentUpdateDto)
        {
            return await UpdateBaseAsync(PaymentUpdateDto, PaymentUpdateDto.Id);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> DeleteAsync(long id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}
