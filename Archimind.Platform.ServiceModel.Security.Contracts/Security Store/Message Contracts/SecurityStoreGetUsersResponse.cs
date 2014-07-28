using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service GetUsers response message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreGetUsersResponse",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreGetUsersResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersResponse"/> class.
        /// </summary>
        public SecurityStoreGetUsersResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersResponse"/> class.
        /// </summary>
        /// <param name="users">The users.</param>
        public SecurityStoreGetUsersResponse(UserDataCollection users)
        {
            this.Users = users;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        [MessageBodyMember]
        public UserDataCollection Users
        {
            get;
            set;
        }

        #endregion
    }
}