using System;
using System.ServiceModel;
using Archimind.Platform.ServiceModel.Security.Contracts;

namespace Archimind.Platform.ServiceModel.Security.Client
{
    /// <summary>
    /// Represents a security store client proxy.
    /// </summary>
    public class SecurityStoreClient : ClientBase<ISecurityStoreService>, ISecurityStoreService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public SecurityStoreClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
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
            return Channel.GetUserById(request);
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
            return Channel.GetUsers(request);
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
            return
                Channel.GetUsersWithFilters(request);
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
            return Channel.CreateUser(request);
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
            return Channel.UpdateUser(request);
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
            return Channel.DeleteUser(request);
        }

        #endregion
    }
}
