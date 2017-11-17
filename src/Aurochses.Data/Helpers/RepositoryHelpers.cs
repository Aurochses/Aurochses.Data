using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aurochses.Data.Helpers
{
    /// <summary>
    /// Helpers of repository for data layer.
    /// </summary>
    public static class RepositoryHelpers
    {
        /// <summary>
        /// Gets entity of type T from repository that satisfies an expression.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>TEntity</cref>.</returns>
        public static TEntity Get<TEntity, TType>(this IRepository<TEntity, TType> repository, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return repository.Get(QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Gets entity of type T from repository by identifier.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><cref>TEntity</cref>.</returns>
        public static TEntity Get<TEntity, TType>(this IRepository<TEntity, TType> repository, TType id)
            where TEntity : IEntity<TType>
        {
            return repository.Get(GetIdFilterExpression<TEntity, TType>(id));
        }

        /// <summary>
        /// Gets model of type T from repository that satisfies an expression.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>TModel</cref></returns>
        public static TModel Get<TModel, TEntity, TType>(this IRepository<TEntity, TType> repository, IDataMapper dataMapper, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return repository.Get<TModel>(dataMapper, QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Gets model of type T from repository by identifier.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><cref>TModel</cref></returns>
        public static TModel Get<TModel, TEntity, TType>(this IRepository<TEntity, TType> repository, IDataMapper dataMapper, TType id)
            where TEntity : IEntity<TType>
        {
            return repository.Get<TModel, TEntity, TType>(dataMapper, GetIdFilterExpression<TEntity, TType>(id));
        }

        /// <summary>
        /// Asynchronously gets entity of type T from repository that satisfies an expression.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>Task{TEntity}</cref>.</returns>
        public static async Task<TEntity> GetAsync<TEntity, TType>(this IRepository<TEntity, TType> repository, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return await repository.GetAsync(QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Asynchronously gets entity of type T from repository by identifier.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><cref>Task{TEntity}</cref>.</returns>
        public static async Task<TEntity> GetAsync<TEntity, TType>(this IRepository<TEntity, TType> repository, TType id)
            where TEntity : IEntity<TType>
        {
            return await repository.GetAsync(GetIdFilterExpression<TEntity, TType>(id));
        }

        /// <summary>
        /// Asynchronously gets model of type T from repository that satisfies an expression.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>Task{TModel}</cref>.</returns>
        public static async Task<TModel> GetAsync<TModel, TEntity, TType>(this IRepository<TEntity, TType> repository, IDataMapper dataMapper, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return await repository.GetAsync<TModel>(dataMapper, QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Asynchronously gets model of type T from repository by identifier.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><cref>Task{TModel}</cref>.</returns>
        public static async Task<TModel> GetAsync<TModel, TEntity, TType>(this IRepository<TEntity, TType> repository, IDataMapper dataMapper, TType id)
            where TEntity : IEntity<TType>
        {
            return await repository.GetAsync<TModel, TEntity, TType>(dataMapper, GetIdFilterExpression<TEntity, TType>(id));
        }

        private static Expression<Func<TEntity, bool>> GetIdFilterExpression<TEntity, TType>(TType id)
            where TEntity : IEntity<TType>
        {
            return x => (object) x.Id == (object) id;
        }

        /// <summary>
        /// Gets entities of type T from repository that satisfies an expression.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        public static IList<TEntity> GetList<TEntity, TType>(this IRepository<TEntity, TType> repository, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return repository.GetList(QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Gets models of type T from repository that satisfies an expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>IList{TModel}</cref>.</returns>
        public static IList<TModel> GetList<TModel, TEntity, TType>(this IRepository<TEntity, TType> repository, IDataMapper dataMapper, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return repository.GetList<TModel>(dataMapper, QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Asynchronously gets entities of type T from repository that satisfies an expression.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>Task{IList{TModel}}</cref>.</returns>
        public static async Task<IList<TEntity>> GetListAsync<TEntity, TType>(this IRepository<TEntity, TType> repository, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return await repository.GetListAsync(QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Asynchronously gets models of type T from repository that satisfies an expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><cref>Task{IList{TModel}}</cref>.</returns>
        public static async Task<IList<TModel>> GetListAsync<TModel, TEntity, TType>(this IRepository<TEntity, TType> repository, IDataMapper dataMapper, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return await repository.GetListAsync<TModel>(dataMapper, QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Checks if entity of type T that satisfies an expression exists in repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        public static bool Exists<TEntity, TType>(this IRepository<TEntity, TType> repository, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return repository.Exists(QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Checks if entity of type T with identifier exists in repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        public static bool Exists<TEntity, TType>(this IRepository<TEntity, TType> repository, TType id)
            where TEntity : IEntity<TType>
        {
            return repository.Exists(GetIdFilterExpression<TEntity, TType>(id));
        }

        /// <summary>
        /// Asynchronously checks if entity of type T that satisfies an expression exists in repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        public static async Task<bool> ExistsAsync<TEntity, TType>(this IRepository<TEntity, TType> repository, Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : IEntity<TType>
        {
            return await repository.ExistsAsync(QueryParameters<TEntity, TType>.Create(filterExpression));
        }

        /// <summary>
        /// Asynchronously checks if entity of type T with identifier exists in repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <typeparam name="TType">The type of the T type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        public static async Task<bool> ExistsAsync<TEntity, TType>(this IRepository<TEntity, TType> repository, TType id)
            where TEntity : IEntity<TType>
        {
            return await repository.ExistsAsync(GetIdFilterExpression<TEntity, TType>(id));
        }
    }
}