using System;

namespace Archimind.Platform.Patterns.UnitOfWork
{
    /// <summary>
    /// Represents the interface of a unit of work.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>The number of changes.</returns>
        int SaveChanges();
    }
}
