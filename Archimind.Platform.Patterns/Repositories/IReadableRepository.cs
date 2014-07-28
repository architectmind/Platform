using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Archimind.Platform.Patterns.Repositories
{
    /// <summary>
    /// Represents the interface of a readable repository.
    /// </summary>
    /// <typeparam name="TSurrogateKey">The type of the surrogate key.</typeparam>
    /// <typeparam name="TNaturalKey">The type of the natural key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IReadableRepository<TSurrogateKey, TNaturalKey, TEntity>
        where TEntity : class, IEntity<TSurrogateKey, TNaturalKey>
    {
        /// <summary>
        /// Finds the by surrogate key.
        /// </summary>
        /// <param name="surrogateKey">The surrogate key.</param>
        /// <returns>The entity.</returns>
        TEntity FindBySurrogateKey(TSurrogateKey surrogateKey);

        /// <summary>
        /// Finds the by natural key.
        /// </summary>
        /// <param name="naturalKey">The natural key.</param>
        /// <returns>The entity.</returns>
        TEntity FindByNaturalKey(TNaturalKey naturalKey);

        /// <summary>
        /// Finds the by an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The entity.</returns>
        TEntity FindBy(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Gets all the entities.
        /// </summary>
        /// <returns>The entities.</returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// Filters the by an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The entities.</returns>
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Gets the by.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>The entities.</returns>
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// Gets the by raw SQL.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The entities.</returns>
        IEnumerable<TEntity> GetByRawSql(string query, params object[] parameters);
    }
}
