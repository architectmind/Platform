using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Archimind.Platform.Patterns.DataContext;

namespace Archimind.Platform.Patterns.Repositories
{
    /// <summary>
    /// Represents a base implementation for a repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class RepositoryBase<TEntity> : IRepository<Guid, string, TEntity>
        where TEntity : class, IEntity<Guid, string>
    {
        #region Members

        private IDataContext dataContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{TEntity}"/> class.
        /// </summary>
        public RepositoryBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{TEntity}"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <exception cref="System.ArgumentNullException">dataContext</exception>
        public RepositoryBase(IDataContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }

            this.dataContext = dataContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        public IDataContext DataContext
        {
            get { return this.dataContext; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds by the surrogate key.
        /// </summary>
        /// <param name="surrogateKey">The surrogate key.</param>
        /// <returns>The entity.</returns>
        public abstract TEntity FindBySurrogateKey(Guid surrogateKey);

        /// <summary>
        /// Finds by the natural key.
        /// </summary>
        /// <param name="naturalKey">The natural key.</param>
        /// <returns>The entity.</returns>
        public abstract TEntity FindByNaturalKey(string naturalKey);

        /// <summary>
        /// Finds by an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The entity.</returns>
        public abstract TEntity FindBy(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        public abstract IQueryable<TEntity> All();

        /// <summary>
        /// Filters by an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>A list of entities.</returns>
        public abstract IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Gets the by.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>A list of entities.</returns>
        public abstract IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// Gets the by raw SQL.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A list of entities.</returns>
        public abstract IEnumerable<TEntity> GetByRawSql(string query, params object[] parameters);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was added.</returns>
        public abstract bool Add(TEntity entity);

        /// <summary>
        /// Adds the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A boolean value indicating if the entities were added.</returns>
        public abstract bool Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was updated.</returns>
        public abstract bool Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was deleted.</returns>
        public abstract bool Delete(TEntity entity);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A boolean value indicating if the entities were deleted.</returns>
        public abstract bool Delete(IEnumerable<TEntity> entities);

        #endregion
    }
}
