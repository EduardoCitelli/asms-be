using ASMS.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASMS.Persistence.Extensions
{
    public static class QueryFilterExtension
    {
        public static ModelBuilder ApplyApplicationQueryFilter(this ModelBuilder modelBuilder, long instituteId)
        {
            modelBuilder.EntitiesOfType<ISoftDeleteEntity>(builder =>
            {
                var param = Expression.Parameter(builder.Metadata.ClrType, "softDeleteEntity");

                var notDeletedExpression = Expression.Equal(Expression.Property(param, nameof(ISoftDeleteEntity.IsDelete)),
                                                            Expression.Constant(false));

                builder.HasQueryFilter(Expression.Lambda(notDeletedExpression, param));
            });

            return modelBuilder;
        }
    }
}