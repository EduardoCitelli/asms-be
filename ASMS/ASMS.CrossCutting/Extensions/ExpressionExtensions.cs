using System.Linq.Expressions;

namespace ASMS.CrossCutting.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] })
                                      .ToDictionary(p => p.s, p => p.f);

            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.And);

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second, Expression.Or);

        public static Expression<Func<T, bool>> AndNot<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) => first.Compose(second.Not(), Expression.And);

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expr) => Expression.Lambda<Func<T, bool>>(Expression.Not(expr.Body), expr.Parameters);
    }
}