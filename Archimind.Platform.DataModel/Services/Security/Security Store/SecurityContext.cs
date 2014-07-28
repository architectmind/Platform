using System;
using System.Data.Entity;
using Archimind.Platform.BusinessEntities.Services;
using Archimind.Platform.DataModel.Orm.EntityFramework.DataContext;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents the database contexto fo the security service.
    /// </summary>
    public class SecurityContext : DatabaseContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityContext"/> class.
        /// </summary>
        public SecurityContext()
            : base()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users
        {
            get;
            set;
        }

        #endregion
    }
}
