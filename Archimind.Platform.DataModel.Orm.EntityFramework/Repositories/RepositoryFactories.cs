using System;
using System.Collections.Generic;
using Archimind.Platform.Patterns.DataContext;
using Archimind.Platform.Patterns;

namespace Archimind.Platform.DataModel.Orm.EntityFramework.Repositories
{
    /// <summary>
    /// Represents a maker of repositories.
    /// </summary>
    public class RepositoryFactories
    {
        #region Members

        private IDictionary<Type, Func<IDataContext, object>> repositoryFactories;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactories"/> class.
        /// </summary>
        public RepositoryFactories()
        {
            this.repositoryFactories = new Dictionary<Type, Func<IDataContext, object>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactories"/> class.
        /// </summary>
        /// <param name="repositoryFactories">The repository factories.</param>
        /// <exception cref="System.ArgumentNullException">repositoryFactories</exception>
        public RepositoryFactories(IDictionary<Type, Func<IDataContext, object>> repositoryFactories)
        {
            if (repositoryFactories == null)
            {
                throw new ArgumentNullException("repositoryFactories");
            }

            this.repositoryFactories = repositoryFactories;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the repository factory.
        /// </summary>
        /// <typeparam name="T">Type serving as the repository factory lookup key.</typeparam>
        /// <returns>The repository function if found, else null.</returns>
        public Func<IDataContext, object> GetRepositoryFactory<T>() where T : class
        {
            Func<IDataContext, object> factory;
            this.repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        /// <summary>
        /// Gets the entity repository factory.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>The entity repository.</returns>
        public Func<IDataContext, object> GetRepositoryFactoryForEntityType<TEntity>() where TEntity : class, IEntity<Guid, string>
        {
            return GetRepositoryFactory<TEntity>() ?? DefaultEntityRepositoryFactory<TEntity>();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Gets the default entity repository factory.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>The entity repository.</returns>
        protected virtual Func<IDataContext, object> DefaultEntityRepositoryFactory<TEntity>() where TEntity : class, IEntity<Guid, string>
        {
            return
                (context) => new Repository<TEntity>(context);
        }

        #endregion
    }
}
