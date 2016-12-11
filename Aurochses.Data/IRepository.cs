namespace Aurochses.Data
{
    /// <summary>
    /// Interface of repository for data layer.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TType">The type of the t type.</typeparam>
    public interface IRepository<TEntity, TType>
        where TEntity : IEntity<TType>
    {
        /// <summary>
        /// Gets entity of type T from repository by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        /// <exception cref="Exceptions.DataNotFoundException">Has exception <see cref="Exceptions.DataNotFoundException"/> if entity is null.</exception>
        TEntity Get(TType id);

        /// <summary>
        /// Finds entity of type T from repository by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        TEntity Find(TType id);

        /// <summary>
        /// Checks if entity of type T with identifier exists in repository.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
        bool Exists(TType id);

        /// <summary>
        /// Saves entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="startTrackProperties">if set to <c>true</c> marks entity as modified.</param>
        /// <returns>TEntity.</returns>
        TEntity InsertOrUpdate(TEntity entity, bool startTrackProperties = false);

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