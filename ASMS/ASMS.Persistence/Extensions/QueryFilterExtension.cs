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

            modelBuilder.EntitiesOfType<IIsInstituteEntity>(builder =>
            {
                var param = Expression.Parameter(builder.Metadata.ClrType, "instituteEntity");

                var insituteIdExpression = Expression.Equal(Expression.Property(param, nameof(IIsInstituteEntity.InstituteId)),
                                                            Expression.Constant(instituteId));

                var notDeletedExpression = Expression.Equal(Expression.Property(param, nameof(ISoftDeleteEntity.IsDelete)),
                                                            Expression.Constant(false));

                var joinExpression = Expression.AndAlso(insituteIdExpression, notDeletedExpression);

                var lambdaExpression = Expression.Lambda(joinExpression, param);

                builder.HasQueryFilter(lambdaExpression);
            });

            return modelBuilder;
        }
    }
}