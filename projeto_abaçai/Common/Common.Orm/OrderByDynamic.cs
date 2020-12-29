using Common.Domain.Base;
using Common.Domain.Enums;
using System;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Reflection;

namespace Common.Orm
{
    public static class OrderByDynamic
    {
        private static IQueryable<T> OrderingHelperDynamic<T>(IQueryable<T> source, string expression)
        {
            return source.OrderBy(expression);
        }

        private static IQueryable<T> OrderByExpression<T>(this IQueryable<T> source, string propertyName)
        {
            var expression = string.Format("{0}", propertyName);
            return OrderingHelperDynamic(source, expression);
        }

        private static IQueryable<T> OrderByDescendingExpression<T>(this IQueryable<T> source, string propertyName)
        {
            var expression = string.Format("{0} Descending", propertyName);
            return OrderingHelperDynamic(source, expression);
        }

        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> source, FilterBase filters, bool verifyProperty = true)
        {
            var sourceOrdering = default(IQueryable<T>);

            if (filters.OrderFields.IsNotNull())
            {
                if (verifyProperty)
                {
                    if (!PropertyExists<T>(filters.OrderFields))
                        return source;
                }

                if (filters.OrderByType == OrderByType.OrderBy)
                    sourceOrdering = OrderByExpression(source, string.Join(",", filters.OrderFields));

                if (filters.OrderByType == OrderByType.OrderByDescending)
                    sourceOrdering = OrderByDescendingExpression(source, string.Join(",", filters.OrderFields));
            }
            else
                sourceOrdering = OrderByExpression(source, "1");

            return sourceOrdering.IsNotNull() ? sourceOrdering : source;
        }


        private static bool PropertyExists<T>(string[] propertyName)
        {
            return typeof(T).GetProperty(DefinePropertyName(propertyName), BindingFlags.IgnoreCase |
              BindingFlags.Public | BindingFlags.Instance) != null;
        }

        private static string DefinePropertyName(string[] propertyName)
        {
            var _propertyName = propertyName.LastOrDefault();
            var _parentProperty = _propertyName.Split('.')[0];
            return _parentProperty;
        }

    }
}