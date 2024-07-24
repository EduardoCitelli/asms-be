using ASMS.CrossCutting.Extensions;
using ASMS.CrossCutting.Utils.Models;
using System.Linq.Expressions;

namespace ASMS.CrossCutting.Utils
{
    public static class CompositeFilter
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, RootFilter filter) where T : class
        {
            if (filter == null || filter.Filters == null || !filter.Filters.Any())
                return query;

            Expression<Func<T, bool>>? compositeFilterExpression = null;

            if (filter.Logic?.ToLower() == "and")
            {
                compositeFilterExpression = GetAndFilterExpression<T>(filter.Filters);
            }
            else if (filter.Logic?.ToLower() == "or")
            {
                compositeFilterExpression = GetOrFilterExpression<T>(filter.Filters);
            }

            return compositeFilterExpression != null
                ? query.Where(compositeFilterExpression)
                : query;
        }

        private static Expression<Func<T, bool>> GetAndFilterExpression<T>(List<Filter> filters) where T : class
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            Expression? andExpression = null;

            foreach (var filter in filters)
            {
                var filterExpression = BuildFilterExpression(filter, parameter);

                if (filterExpression != null)
                    andExpression = andExpression == null ? filterExpression : Expression.AndAlso(andExpression, filterExpression);
            }

            andExpression ??= Expression.Constant(false);

            return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
        }

        private static Expression<Func<T, bool>>? GetOrFilterExpression<T>(List<Filter> filters) where T : class
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? orExpression = null;

            foreach (var filter in filters)
            {
                var filterExpression = BuildFilterExpression(filter, parameter);

                if (filterExpression != null)
                    orExpression = orExpression == null ? filterExpression : Expression.OrElse(orExpression, filterExpression);
            }

            orExpression ??= Expression.Constant(false);

            return Expression.Lambda<Func<T, bool>>(orExpression, parameter);
        }

        private static Expression? BuildFilterExpression(Filter filter, ParameterExpression parameter)
        {
            if (filter.Filters != null && filter.Filters.Any())
            {
                if (filter.Logic?.ToLower() == "and")
                {
                    var andFilters = filter.Filters.Select(f => BuildFilterExpression(f, parameter));
                    return andFilters.Aggregate(Expression.AndAlso);
                }
                else if (filter.Logic?.ToLower() == "or")
                {
                    var orFilters = filter.Filters.Select(f => BuildFilterExpression(f, parameter));
                    return orFilters.Aggregate(Expression.OrElse);
                }
            }

            if (filter.Value == null || string.IsNullOrWhiteSpace(filter.Value.ToString()))
                return null;

            MemberExpression selector = null;
            Expression current = parameter;

            foreach (var part in filter.Field.Split('.'))
            {
                selector = Expression.PropertyOrField(current, part);
                current = selector;
            }

            var property = current;
            var constant = Expression.Constant(filter.Value);

            switch (filter.Operator.ToLower())
            {
                case OperationFilters.equal:
                    return Expression.Equal(property, constant);

                case OperationFilters.notEqual:
                    return Expression.NotEqual(property, constant);

                case OperationFilters.lessThan:
                    return Expression.LessThan(property, constant);

                case OperationFilters.lessThanOrEqual:
                    return Expression.LessThanOrEqual(property, constant);

                case OperationFilters.greaterThan:
                    return Expression.GreaterThan(property, constant);

                case OperationFilters.greaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(property, constant);

                case OperationFilters.contains:
                    var containsMethod = StringExtensions.GetStringMethodWithOneStringParameter(nameof(string.Contains));
                    return Expression.Call(property, containsMethod, constant);

                case OperationFilters.startWith:
                    var startsWithMethod = StringExtensions.GetStringMethodWithOneStringParameter(nameof(string.StartsWith));
                    return Expression.Call(property, startsWithMethod, constant);

                default:
                    throw new ArgumentException($"Unsupported operator: {filter.Operator}");
            }
        }
    }
}