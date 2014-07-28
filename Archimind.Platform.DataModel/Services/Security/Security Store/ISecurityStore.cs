using System;
using Archimind.Platform.BusinessEntities.Services;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents the interface of a security store.
    /// </summary>
    public interface ISecurityStore : IDataModelServiceBase, IDisposable
    {
        /// <summary>
        /// Creates the specified security store.
        /// </summary>
        /// <param name="securityStore">The security store.</param>
        void Create(string securityStore);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void CreateUser(User user);

        /// <summary>
        /// Reads the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user object.</returns>
        User ReadUser(Guid id);

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
