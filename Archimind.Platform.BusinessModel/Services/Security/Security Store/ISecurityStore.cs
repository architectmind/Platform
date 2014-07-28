using System;
using System.Collections.Generic;
using Archimind.Platform.BusinessEntities.Services;
using System.Linq.Expressions;

namespace Archimind.Platform.BusinessModel.Services
{
    /// <summary>
    /// Represents the interface of a security store in the business model.
    /// </summary>
    public interface ISecurityStore : IBusinessModelServiceBase
    {
        /// <summary>
        /// Reads the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user object.</returns>
        User ReadUser(Guid id);

        /// <summary>
        /// Reads the users.
        /// </summary>
        /// <returns>The list of users.</returns>
        IEnumerable<User> ReadUsers();

        /// <summary>
        /// Reads the users with filter.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns>The list of users.</returns>
        IEnumerable<User> ReadUsersWithFilter(Expression<Func<User, bool>> filterExpression);

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
    }
}
