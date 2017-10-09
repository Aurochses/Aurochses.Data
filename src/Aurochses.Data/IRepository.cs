using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aurochses.Data
{
    /// <summary>
    /// Interface of repository for data layer.
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    /// <typeparam name="TType">The type of the T type.</typeparam>
    public interface IRepository<TEntity, TType>
        where TEntity : IEntity<TType>
    {
        /// <summary>
        /// Gets entity of type T from repository by identifier.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        TEntity Get(TType id);

        /// <summary>
        /// Gets model of type T from repository by identifier.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>TModel</returns>
        TModel Get<TModel>(IDataMapper dataMapper, TType id);

        /// <summary>
        /// Asynchronously gets entity of type T from repository by identifier.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><cref>TEntity</cref>.</returns>
        Task<TEntity> GetAsync(TType id);

        /// <summary>
        /// Asynchronously gets model of type T from repository by identifier.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TModel&gt;.</returns>
        Task<TModel> GetAsync<TModel>(IDataMapper dataMapper, TType id);

        /// <summary>
        /// Gets enities of type T from repository that satisfies a query parameters.
        /// </summary>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        IList<TEntity> GetList(QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Gets models of type T from repository that satisfies a query parameters.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>IList&lt;TModel&gt;.</returns>
        IList<TModel> GetList<TModel>(IDataMapper dataMapper, QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Asynchronously gets enities of type T from repository that satisfies a query parameters.
        /// </summary>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        Task<IList<TEntity>> GetListAsync(QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Asynchronously gets models of type T from repository that satisfies a query parameters.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>Task&lt;IList&lt;TModel&gt;&gt;.</returns>
        Task<IList<TModel>> GetListAsync<TModel>(IDataMapper dataMapper, QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Checks if entity of type T with identifier exists in repository.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        bool Exists(TType id);

        /// <summary>
        /// Asynchronously checks if entity of type T with identifier exists in repository.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        Task<bool> ExistsAsync(TType id);

        /// <summary>
        /// Checks if any entity of type T satisfies a query parameters.
        /// </summary>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        bool Exists(QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Asynchronously checks if any entity of type T satisfies a query parameters.
        /// </summary>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        Task<bool> ExistsAsync(QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Returns a number that represents how many entities in repository satisfy a query parameters.
        /// </summary>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>A number that represents how many entities in repository satisfy a query parameters.</returns>
        int Count(QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Asynchronously returns a number that represents how many entities in repository satisfy a query parameters.
        /// </summary>
        /// <param name="queryParameters">Query parameters.</param>
        /// <returns>A number that represents how many entities in repository satisfy a query parameters.</returns>
        Task<int> CountAsync(QueryParameters<TEntity, TType> queryParameters = null);

        /// <summary>
        /// Inserts entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity.</returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Asynchronously inserts entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><cref>TEntity</cref>.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Updates entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="startTrackProperties">if set to <c>true</c> marks entity as modified.</param>
        /// <returns>TEntity.</returns>
        TEntity Update(TEntity entity, bool startTrackProperties = false);

        /// <summary>
        /// Deletes the specified entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(TType id);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);
    }
}