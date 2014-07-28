using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;
using Archimind.Platform.ServiceModel.Security.Contracts;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF;

namespace Archimind.Platform.ServiceModel.Security.Services
{
    /// <summary>
    /// Security store service implementation.
    /// </summary>
    [ServiceBehavior(
        Name = "SecurityStoreService",
        Namespace = ServiceModelConstants.ServiceDefaultNamespace,
        InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Single)]
    [ExceptionShielding("ServiceLayer")]
    public sealed class SecurityStoreService : ISecurityStoreService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreService"/> class.
        /// </summary>
        public SecurityStoreService()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The user data.
        /// </returns>
        public SecurityStoreGetUserByIdResponse GetUserById(SecurityStoreGetUserByIdRequest request)
        {
            SecurityStoreServiceAdapter adapter = new SecurityStoreServiceAdapter();
            return adapter.GetUserById(request);
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The get users response message.
        /// </returns>
        public SecurityStoreGetUsersResponse GetUsers(SecurityStoreGetUsersRequest request)
        {
            SecurityStoreServiceAdapter adapter = new SecurityStoreServiceAdapter();
            return adapter.GetUsers(request);
        }

        /// <summary>
        /// Gets the users with filters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The get users with filter response message.
        /// </returns>
        public SecurityStoreGetUsersWithFiltersResponse GetUsersWithFilters(SecurityStoreGetUsersWithFiltersRequest request)
        {
            SecurityStoreServiceAdapter adapter = new SecurityStoreServiceAdapter();
            return adapter.GetUsersWithFilters(request);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The create user response message.
        /// </returns>
        public SecurityStoreCreateUserResponse CreateUser(SecurityStoreCreateUserRequest request)
        {
            SecurityStoreServiceAdapter adapter = new SecurityStoreServiceAdapter();
            return adapter.CreateUser(request);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The update user response message.
        /// </returns>
        public SecurityStoreUpdateUserResponse UpdateUser(SecurityStoreUpdateUserRequest request)
        {
            SecurityStoreServiceAdapter adapter = new SecurityStoreServiceAdapter();
            return adapter.UpdateUser(request);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The delete user response message.
        /// </returns>
        public SecurityStoreDeleteUserResponse DeleteUser(SecurityStoreDeleteUserRequest request)
        {
            SecurityStoreServiceAdapter adapter = new SecurityStoreServiceAdapter();
            return adapter.DeleteUser(request);
        }

        #endregion
    }
}
