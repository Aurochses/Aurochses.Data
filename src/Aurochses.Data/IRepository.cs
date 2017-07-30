using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aurochses.Data
{
    /// <summary>
    /// Interface of repository for data layer.
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    /// <typeparam name="TType">The type of the T type.</typeparam>
    public interface IRepository<TEntity, in TType>
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
        /// <param name="mapper">The mapper.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>TModel</returns>
        TModel Get<TModel>(IMapper mapper, TType id);

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
        /// <param name="mapper">The mapper.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TModel&gt;.</returns>
        Task<TModel> GetAsync<TModel>(IMapper mapper, TType id);

        /// <summary>
        /// Finds enities of type T from repository.
        /// </summary>
        /// <param name="filter">Query filter.</param>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        IList<TEntity> Find(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Finds models of type T from repository.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="mapper">The mapper.</param>
        /// <param name="filter">Query filter.</param>
        /// <returns>IList&lt;TModel&gt;.</returns>
        IList<TModel> Find<TModel>(IMapper mapper, Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Asynchronously finds enities of type T from repository.
        /// </summary>
        /// <param name="filter">Query filter.</param>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Asynchronously finds models of type T from repository.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="mapper">The mapper.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;IList&lt;TModel&gt;&gt;.</returns>
        Task<IList<TModel>> FindAsync<TModel>(IMapper mapper, Expression<Func<TEntity, bool>> filter = null);

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
        /// Checks if entity of type T exists in repository.
        /// </summary>
        /// <param name="filter">Query filter.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        bool Exists(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Asynchronously checks if entity of type T exists in repository.
        /// </summary>
        /// <param name="filter">Query filter.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter = null);

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