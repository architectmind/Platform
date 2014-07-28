using System;

namespace Archimind.Platform.Patterns.Registry
{
    /// <summary>
    /// Represents the interface of a registry.
    /// </summary>
    public interface IRegistry<TKey, TEntry> 
        where TKey : class 
        where TEntry : class
    {
        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <param name="entryKey">The entry key.</param>
        /// <returns>The entry.</returns>
        TEntry GetEntry(TKey entryKey);

        /// <summary>
        /// Sets the entry.
        /// </summary>
        /// <param name="entryKey">The entry key.</param>
        /// <param name="entry">The entry.</param>
        void SetEntry(TKey entryKey, TEntry entry);
    }
}
