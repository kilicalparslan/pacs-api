
using pdksApi.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;


namespace pdksApi.Core.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] inculedes) where T : class
        {
            if (inculedes != null)
            {
                query = inculedes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public static IOrderedQueryable<T> AscOrDescOrder<T>(this IQueryable<T> query, Esort eSort, string propertyName)
        {
            var entityType = typeof(T);
            var properyInfo = entityType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (properyInfo == null)
                properyInfo = entityType.GetProperty("Id");
            var arg = Expression.Parameter(entityType, "x");
            var property = Expression.Property(arg, properyInfo.Name);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });
            var enumarableType = typeof(Queryable);
            var sortType = eSort == Esort.ASC ? "OrderBy" : "OrderByDescending";
            var method = enumarableType.GetMethods().Where(m => m.Name == sortType && m.IsGenericMethodDefinition).Where(m =>
                  {
                      var parameters = m.GetParameters().ToList();
                      return parameters.Count == 2;
                  }).Single();
            var genericMethod = method.MakeGenericMethod(entityType, properyInfo.PropertyType);
            var newQuery = (IOrderedQueryable<T>)genericMethod.Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }

    }
}
