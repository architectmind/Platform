using System;
using System.Collections.Generic;
using System.Linq;

namespace Archimind.Platform.Patterns.Repositories
{
    /// <summary>
    /// Represents the interface of a persistable repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IPersistableRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was added.</returns>
        bool Add(TEntity entity);

        /// <summary>
        /// Adds the specified items.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A boolean value indicating if the entities were added.</returns>
        bool Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was updated.</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was deleted.</returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A boolean value indicating if the entities were added.</returns>
        bool Delete(IEnumerable<TEntity> entities);
    }
}
