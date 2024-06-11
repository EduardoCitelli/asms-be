using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Payments;
using ASMS.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ASMS.Services.Abstractions
{
    public interface IPaymentService
    {
        Task<BaseApiResponse<PagedList<PaymentListDto>>> GetListAsync(int pageNumber = 1, 
                                                                      int pageSize = 10, 
                                                                      Func<IQueryable<Payment>, IIncludableQueryable<Payment, object>>? include = null);
        Task<BaseApiResponse<PagedList<PaymentListDto>>> GetListQueryAsync(Expression<Func<Payment, bool>> query, 
                                                                           int pageNumber = 1, 
                                                                           int pageSize = 10, 
                                                                           Func<IQueryable<Payment>, IIncludableQueryable<Payment, object>>? include = null);
        Task<BaseApiResponse<PaymentSingleDto>> GetOneAsync(int id);
        Task<BaseApiResponse<PaymentSingleDto>> CreateAsync(PaymentCreateDto PaymentCreateDto);
        Task<BaseApiResponse<PaymentSingleDto>> DeleteAsync(int id);
        Task<bool> ExistEntityAsync(Expression<Func<Payment, bool>> expression);
        Task<BaseApiResponse<PaymentSingleDto>> UpdateAsync(PaymentUpdateDto PaymentUpdateDto);
    }
}