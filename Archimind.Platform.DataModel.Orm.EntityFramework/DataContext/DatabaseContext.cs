using System;
using System.Data.Entity;
using Archimind.Platform.Patterns.DataContext;

namespace Archimind.Platform.DataModel.Orm.EntityFramework.DataContext
{
    /// <summary>
    /// Represents a concrete data context.
    /// </summary>
    public class DatabaseContext : DbContext, IDataContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        public DatabaseContext()
            : base()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public override int SaveChanges()
        {
            return
                base.SaveChanges();
        }
        
        #endregion
    }
}
