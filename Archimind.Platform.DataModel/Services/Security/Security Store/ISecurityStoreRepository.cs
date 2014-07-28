using Archimind.Platform.BusinessEntities.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents the interface of a security store repository.
    /// </summary>
    public interface ISecurityStoreRepository : IDisposable
    {
        #region Public Methods

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>The users.</returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Gets the users with filter.
        /// </summary>
        /// <param name="filterExpression">The filter.</param>
        /// <returns>The users.</returns>
        IEnumerable<User> GetUsersWithFilter(Expression<Func<User, bool>> filterExpression);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user.</returns>
        User GetUserById(Guid id);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void CreateUser(User user);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteUser(Guid id);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        #endregion
    }
}
