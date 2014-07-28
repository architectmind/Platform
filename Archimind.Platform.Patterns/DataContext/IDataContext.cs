using System;

namespace Archimind.Platform.Patterns.DataContext
{
    /// <summary>
    /// Represents the base interface for a data context.
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>The number of changes.</returns>
        int SaveChanges();
    }
}
