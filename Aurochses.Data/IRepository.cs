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
        /// Gets enities of type T from repository.
        /// </summary>
        /// <param name="filter">Query filter.</param>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Asynchronously gets entity of type T from repository by identifier.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><cref>Task{TEntity}</cref>.</returns>
        Task<TEntity> GetAsync(TType id);

        /// <summary>
        /// Asynchronously gets enities of type T from repository.
        /// </summary>
        /// <param name="filter">Query filter.</param>
        /// <returns><cref>Task{IList{TEntity}}</cref>.</returns>
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);

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
        /// Saves entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="startTrackProperties">if set to <c>true</c> marks entity as modified.</param>
        /// <returns>TEntity.</returns>
        TEntity InsertOrUpdate(TEntity entity, bool startTrackProperties = false);

        /// <summary>
        /// Asynchronously saves entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="startTrackProperties">if set to <c>true</c> marks entity as modified.</param>
        /// <returns><cref>Task{TEntity}</cref>.</returns>
        Task<TEntity> InsertOrUpdateAsync(TEntity entity, bool startTrackProperties = false);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes the specified entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(TType id);
    }
}