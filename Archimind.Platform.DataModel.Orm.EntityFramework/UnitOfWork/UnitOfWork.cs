using System;
using Archimind.Platform.DataModel.Orm.EntityFramework.DataContext;
using Archimind.Platform.DataModel.Orm.EntityFramework.Repositories;
using Archimind.Platform.Patterns.UnitOfWork;
using Archimind.Platform.Patterns;

namespace Archimind.Platform.DataModel.Orm.EntityFramework.UnitOfWork
{
    /// <summary>
    /// Represents a implementation of a unit of work.
    /// </summary>
    public class EntitiesUnitOfWork : UnitOfWorkBase
    {
        #region Construtors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntitiesUnitOfWork"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        /// <param name="repositoryRegistry">The repository registry.</param>
        public EntitiesUnitOfWork(DatabaseContext databaseContext, RepositoryRegistry repositoryRegistry)
            : base(databaseContext, repositoryRegistry)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>The repository for the entity.</returns>
        public Repository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity<Guid, string>
        {
            RepositoryRegistry repositoryRegistry = this.Registry as RepositoryRegistry;

            return
                repositoryRegistry.GetRepositoryForEntityType<TEntity>(this.DataContext);
        }


        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>
        /// The number of changes.
        /// </returns>
        public override int SaveChanges()
        {
            return
                this.DataContext.SaveChanges();
        }

        #endregion
    }
}
