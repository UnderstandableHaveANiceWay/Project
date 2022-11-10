using ProjectV2.Domain;
using System.Linq.Expressions;

namespace ProjectV2.Dal.Interfaces
{
    public static class QueryableRepositoryExtensions
    {
        public static bool ExistInDbByEntityWithProperties<TEntity>(
            this IRepository<TEntity> repository,
            TEntity entity,
            params string[] propertieNames)
            where TEntity : BaseEntity
        {
            if (propertieNames.Length < 1) return false;

            var entitiesWithSameProperties = EqualityOfProperties(repository.GetIQueryableAll(), entity, propertieNames);

            if (entitiesWithSameProperties.All((x) => false))
            {
                return false;
            }
            return true;
        }

        private static IQueryable<TEntity> EqualityOfProperties<TEntity>(
            IQueryable<TEntity> entities,
            TEntity entity,
            string[] propertieNames)
            where TEntity : BaseEntity
        {
            IQueryable<TEntity> entitiesWithCheck = entities;
            foreach (var pName in propertieNames)
            {
                entitiesWithCheck = entitiesWithCheck.Where(EqualityExpressionToLambda(pName, entity));
            }
            return entitiesWithCheck;
        }
        private static Expression<Func<TEntity, bool>> EqualityExpressionToLambda<TEntity>(
            string propertyName,
            TEntity entity)
            where TEntity : BaseEntity
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            var checkProperty = entity.GetType().GetProperty(propertyName);
            var checkPropertyValue = checkProperty.GetValue(entity);
            var checkPropertyConstant = Expression.Constant(checkPropertyValue);
            var checkPropertyAsObject = Expression.Convert(checkPropertyConstant, typeof(object));

            var compareProperies = Expression.Equal(propAsObject, checkPropertyAsObject);

            return Expression.Lambda<Func<TEntity, bool>>(compareProperies, parameter);
        }
    }
}
