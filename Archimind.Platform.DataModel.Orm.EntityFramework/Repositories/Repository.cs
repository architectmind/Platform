using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Archimind.Platform.DataModel.Orm.EntityFramework.DataContext;
using Archimind.Platform.Patterns;
using Archimind.Platform.Patterns.DataContext;
using Archimind.Platform.Patterns.Repositories;

namespace Archimind.Platform.DataModel.Orm.EntityFramework.Repositories
{
    /// <summary>
    /// Represents a concrete repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity<Guid, string>
    {
        #region Members

        private IDbSet<TEntity> set;

        #endregion

        #region Construtors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        public Repository()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public Repository(IDataContext dataContext)
            : base(dataContext)
        {
            DbContext context = dataContext as DbContext;
            this.set = context.Set<TEntity>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds the by surrogate key.
        /// </summary>
        /// <param name="surrogateKey">The surrogate key.</param>
        /// <returns>The entity.</returns>
        public override TEntity FindBySurrogateKey(Guid surrogateKey)
        {
            return
                this.set.Find(surrogateKey);
        }

        /// <summary>
        /// Finds the by natural key.
        /// </summary>
        /// <param name="naturalKey">The natural key.</param>
        /// <returns>The entity.</returns>
        public override TEntity FindByNaturalKey(string naturalKey)
        {
            return                
                this.FindBy(e => e.NaturalKey == naturalKey);
                
        }

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The entity.</returns>
        public override TEntity FindBy(Expression<Func<TEntity, bool>> expression)
        {
            return
                this.FilterBy(expression)
                .SingleOrDefault();
        }

        /// <summary>
        /// Gets all the entities from the database.
        /// </summary>
        /// <returns>The list of entities.</returns>
        public override IQueryable<TEntity> All()
        {
            return
                this.set;
        }

        /// <summary>
        /// Filters the by.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The list of entities filtered by the expression.</returns>
        public override IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            return
                this.All()
                .Where(expression)
                .AsQueryable();
        }

        /// <summary>
        /// Gets the by.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>The list of entities.</returns>
        public override IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = this.All();

            // Add filter condition

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Add include properties for eager loading

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // Add order by clause

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Gets the by raw SQL.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The list of entities.</returns>
        public override IEnumerable<TEntity> GetByRawSql(string query, params object[] parameters)
        {
            DbSet<TEntity> dbSet = set as DbSet<TEntity>;   
            return 
                dbSet.SqlQuery(query, parameters).ToList();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was added.</returns>
        public override bool Add(TEntity entity)
        {
            this.set.Add(entity);

            return true;
        }

        /// <summary>
        /// Adds the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A boolean value indicating if the entities were added.</returns>
        public override bool Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.set.Add(entity);
            }

            return true;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was updated.</returns>
        public override bool Update(TEntity entity)
        {
            DbContext context = this.DataContext as DbContext;
            context.Entry(entity).State = EntityState.Modified;

            return true;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A boolean value indicating if the entity was deleted.</returns>
        public override bool Delete(TEntity entity)
        {
            this.set.Remove(entity);

            return true;
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A boolean value indicating if the entities were deleted.</returns>
        public override bool Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.set.Remove(entity);
            }

            return true;
        }

        #endregion
    }
}