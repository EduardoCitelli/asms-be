using ASMS.CrossCutting.Utils;
using ASMS.Domain.Entities;
using ASMS.DTOs.Payments;
using ASMS.DTOs.Shared;
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

        Task<BaseApiResponse<PagedList<PaymentListDto>>> GetListAsync(PagedFilterRequestDto request,
                                                                      Expression<Func<Payment, bool>>? query = null,
                                                                      Func<IQueryable<Payment>, IIncludableQueryable<Payment, object?>>? include = null,
                                                                      Expression<Func<Payment, object>>? orderBy = null,
                                                                      bool isDesc = false);
        Task<BaseApiResponse<PaymentSingleDto>> GetOneAsync(long id,
                                                            Func<IQueryable<Payment>, IIncludableQueryable<Payment, object?>>? include = null);

        Task<BaseApiResponse<PaymentSingleDto>> CreateAsync(PaymentCreateDto PaymentCreateDto, Action<Payment>? actionBeforeSave = null);

        Task<BaseApiResponse<PaymentSingleDto>> DeleteAsync(long id);

        Task<bool> ExistEntityAsync(Expression<Func<Payment, bool>> expression);

        Task<BaseApiResponse<PaymentSingleDto>> UpdateAsync(PaymentUpdateDto PaymentUpdateDto);
    }
}