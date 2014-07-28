using System;
using System.Collections.Generic;
using Archimind.Platform.BusinessEntities.Services;
using Archimind.Platform.DataModel;
using System.Linq.Expressions;

namespace Archimind.Platform.BusinessModel.Services
{
    /// <summary>
    /// Represents a concrete security store service in the business model.
    /// </summary>
    public sealed class SecurityStore : BusinessModelServiceBase, ISecurityStore
    {
        #region Members

        private bool disposed = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStore"/> class.
        /// </summary>
        public SecurityStore()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStore"/> class.
        /// </summary>
        /// <param name="dataModelManager">The data model manager.</param>
        public SecurityStore(DataModelManager dataModelManager)
            : base(dataModelManager)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Reads the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user object.
        /// </returns>
        public User ReadUser(Guid id)
        {
            return
                this.dataModelManager.SecurityStoreRepository.GetUserById(id);
        }

        /// <summary>
        /// Reads the users.
        /// </summary>
        /// <returns>
        /// The list of users.
        /// </returns>
        public IEnumerable<User> ReadUsers()
        {
            return
                this.dataModelManager.SecurityStoreRepository.GetUsers();
        }

        /// <summary>
        /// Reads the users with filter.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns>
        /// The list of users.
        /// </returns>
        public IEnumerable<User> ReadUsersWithFilter(Expression<Func<User, bool>> filterExpression)
        {
            return
                this.dataModelManager.SecurityStoreRepository.GetUsersWithFilter(filterExpression);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void CreateUser(User user)
        {
            this.dataModelManager.SecurityStoreRepository.CreateUser(user);
            this.dataModelManager.SecurityStoreRepository.Save();
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void UpdateUser(User user)
        {
            this.dataModelManager.SecurityStoreRepository.UpdateUser(user);
            this.dataModelManager.SecurityStoreRepository.Save();
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUser(Guid id)
        {
            this.dataModelManager.SecurityStoreRepository.DeleteUser(id);
            this.dataModelManager.SecurityStoreRepository.Save();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public new void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dataModelManager.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}