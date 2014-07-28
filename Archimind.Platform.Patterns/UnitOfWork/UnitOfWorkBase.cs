using System;
using Archimind.Platform.Patterns.DataContext;
using Archimind.Platform.Patterns.Registry;

namespace Archimind.Platform.Patterns.UnitOfWork
{
    /// <summary>
    /// Represents a base implmentation for a unit of work.
    /// </summary>
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        #region Members

        private IDataContext dataContext;
        private IRegistry<Type, object> registry;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkBase"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="registry">The registry.</param>
        /// <exception cref="System.ArgumentNullException">
        /// dataContext
        /// or
        /// registry
        /// </exception>
        public UnitOfWorkBase(IDataContext dataContext, IRegistry<Type, object> registry)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }

            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            this.dataContext = dataContext;
            this.registry = registry;
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

        /// <summary>
        /// Gets the registry.
        /// </summary>
        /// <value>
        /// The registry.
        /// </value>
        public IRegistry<Type, object> Registry
        {
            get { return this.registry; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>
        /// The number of changes.
        /// </returns>
        public abstract int SaveChanges();

        #endregion
    }
}
