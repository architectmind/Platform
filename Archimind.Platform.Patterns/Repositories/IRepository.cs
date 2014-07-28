using System;

namespace Archimind.Platform.Patterns.Repositories
{
    /// <summary>
    /// Represents a readable and persistable repository.
    /// </summary>
    /// <typeparam name="TSurrogateKey">The type of the surrogate key.</typeparam>
    /// <typeparam name="TNaturalKey">The type of the natural key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TSurrogateKey, TNaturalKey, TEntity> 
        : IReadableRepository<TSurrogateKey, TNaturalKey, TEntity>, IPersistableRepository<TEntity> 
        where TEntity : class, IEntity<TSurrogateKey, TNaturalKey>
    {
    }
}
