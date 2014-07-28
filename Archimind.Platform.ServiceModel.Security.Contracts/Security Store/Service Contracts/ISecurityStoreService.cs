using System;
using System.Net.Security;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;
using Archimind.Platform.ServiceModel.Exceptions;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service contract.
    /// </summary>
    [ServiceContract(
        Name = "ISecurityStoreService",
        Namespace = ServiceModelConstants.ServiceDefaultNamespace,
        ProtectionLevel = ProtectionLevel.None,
        SessionMode = SessionMode.Allowed)]
    public interface ISecurityStoreService
    {
        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The get user by id response message.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceHandledFault))]
        SecurityStoreGetUserByIdResponse GetUserById(SecurityStoreGetUserByIdRequest request);

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The get users response message.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceHandledFault))]
        SecurityStoreGetUsersResponse GetUsers(SecurityStoreGetUsersRequest request);

        /// <summary>
        /// Gets the users with filters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The get users with filter response message.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceHandledFault))]
        SecurityStoreGetUsersWithFiltersResponse GetUsersWithFilters(SecurityStoreGetUsersWithFiltersRequest request);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The create user response message.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceHandledFault))]
        SecurityStoreCreateUserResponse CreateUser(SecurityStoreCreateUserRequest request);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The update user response message.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceHandledFault))]
        SecurityStoreUpdateUserResponse UpdateUser(SecurityStoreUpdateUserRequest request);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The delete user response message.</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceHandledFault))]
        SecurityStoreDeleteUserResponse DeleteUser(SecurityStoreDeleteUserRequest request);
    }
}
