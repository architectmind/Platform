using System;
using System.Collections.Generic;

namespace Archimind.Platform.Patterns.Registry
{
    /// <summary>
    /// Represents a base implementation for a registry.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TEntry">The type of the entry.</typeparam>
    public abstract class RegistryBase<TKey, TEntry> : IRegistry<TKey, TEntry>
        where TKey : class
        where TEntry : class
    {
        #region Members

        /// <summary>
        /// The registry.
        /// </summary>
        protected IDictionary<TKey, TEntry> registry;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryBase{TKey, TEntry}"/> class.
        /// </summary>
        public RegistryBase()
        {
            this.registry = new Dictionary<TKey, TEntry>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryBase{TKey, TEntry}"/> class.
        /// </summary>
        /// <param name="registry">The registry.</param>
        /// <exception cref="System.ArgumentNullException">registry</exception>
        public RegistryBase(IDictionary<TKey, TEntry> registry)
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
        /// Gets the entry.
        /// </summary>
        /// <param name="entryKey">The entry key.</param>
        /// <returns>The entry.</returns>
        public TEntry GetEntry(TKey entryKey)
        {
            return
                this.registry[entryKey];
        }

        /// <summary>
        /// Sets the entry.
        /// </summary>
        /// <param name="entryKey">The entry key.</param>
        /// <param name="entry">The entry.</param>
        public void SetEntry(TKey entryKey, TEntry entry)
        {
            this.registry[entryKey] = entry;
        }

        #endregion
    }
}
