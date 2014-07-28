using System;
using System.Collections.Generic;
using Archimind.Platform.Patterns;
using Archimind.Platform.Patterns.DataContext;
using Archimind.Platform.Patterns.Registry;
using Archimind.Platform.Patterns.Repositories;

namespace Archimind.Platform.DataModel.Orm.EntityFramework.Repositories
{
    /// <summary>
    /// Represents a implementation of a repository registry.
    /// </summary>
    public sealed class RepositoryRegistry : RegistryBase<Type, object>
    {
        #region Members
        // @TODO: implement RegistryBase, Singleton and move DataContext to UnitOfWork implementation.
        private readonly RepositoryFactories repositoryFactories;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryRegistry"/> class.
        /// </summary>
        /// <param name="repositoryFactories">The repository factories.</param>
        /// <exception cref="System.ArgumentNullException">repositoryFactories</exception>
        public RepositoryRegistry(RepositoryFactories repositoryFactories)
            : base()
        {
            if (repositoryFactories == null)
            {
                throw new ArgumentNullException("repositoryFactories");
            }

            this.repositoryFactories = repositoryFactories;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryRegistry"/> class.
        /// </summary>
        /// <param name="repositoryFactories">The repository factories.</param>
        /// <param name="registry">The registry.</param>
        /// <exception cref="System.ArgumentNullException">registry</exception>
        public RepositoryRegistry(RepositoryFactories repositoryFactories, IDictionary<Type, object> registry)
            : this(repositoryFactories)
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            this.registry = registry;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the repository for the entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>The repository for the entity.</returns>
        public Repository<TEntity> GetRepositoryForEntityType<TEntity>(IDataContext dataContext) where TEntity : class, IEntity<Guid, string>
        {
            return
                this.GetRepository<Repository<TEntity>>(
                    dataContext,
                    this.repositoryFactories.GetRepositoryFactoryForEntityType<TEntity>());
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataContext">The data context.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>The repository.</returns>
        public T GetRepository<T>(IDataContext dataContext, Func<IDataContext, object> factory = null) where T : class
        {
            object cachedRepository;

            if (this.registry.TryGetValue(typeof(T), out cachedRepository))
            {
                return (T)cachedRepository;
            }

            // if not found, build a new repository.

            return
                BuildRepository<T>(dataContext, factory);
        }

        /// <summary>
        /// Sets the repository.
        /// </summary>
        /// <typeparam name="T">The repository type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException">repository</exception>
        public void SetRepository<T>(T repository) where T : class
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            this.registry[typeof(T)] = repository;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Builds the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataContext">The data context.</param>
        /// <param name="factory">The factory.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Factory not implemented.</exception>
        private T BuildRepository<T>(IDataContext dataContext, Func<IDataContext, object> factory = null) where T : class
        {
            // Get the repository factory.

            var repositoryFactory = factory ?? this.repositoryFactories.GetRepositoryFactory<T>();

            if (repositoryFactory == null)
            {
                throw new NotImplementedException("Factory not implemented.");
            }

            // Build the repository.

            var repository = (T)repositoryFactory(dataContext);

            // Cache the repository.

            this.SetRepository<T>(repository);

            // Return.

            return repository;
        }

        #endregion
    }
}
