using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service GetUsersWithFilters response message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreGetUsersWithFiltersResponse",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreGetUsersWithFiltersResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersWithFiltersResponse"/> class.
        /// </summary>
        public SecurityStoreGetUsersWithFiltersResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersWithFiltersResponse"/> class.
        /// </summary>
        /// <param name="users">The users.</param>
        public SecurityStoreGetUsersWithFiltersResponse(UserDataCollection users)
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