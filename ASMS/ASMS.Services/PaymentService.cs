using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Payments;
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

        public async Task<BaseApiResponse<PagedList<PaymentListDto>>> GetListQueryAsync(Expression<Func<Payment, bool>> query,
                                                                                        int pageNumber = 1,
                                                                                        int pageSize = 10,
                                                                                        Func<IQueryable<Payment>, IIncludableQueryable<Payment, object>>? include = null)
        {
            return await GetAllDtosPaginatedBaseAsync(pageNumber, pageSize, query, include);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> GetOneAsync(int id)
        {
            return await GetOneDtoBaseAsync(id);
        }

        public async Task<bool> ExistEntityAsync(Expression<Func<Payment, bool>> expression)
        {
            return await ExistBaseAsync(expression);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> CreateAsync(PaymentCreateDto PaymentCreateDto)
        {
            return await CreateBaseAsync(PaymentCreateDto);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> UpdateAsync(PaymentUpdateDto PaymentUpdateDto)
        {
            return await UpdateBaseAsync(PaymentUpdateDto, PaymentUpdateDto.Id);
        }

        public async Task<BaseApiResponse<PaymentSingleDto>> DeleteAsync(int id)
        {
            return await DeleteBaseAsync(id);
        }
    }
}
