using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service GetUserById response message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreGetUserByIdResponse",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreGetUserByIdResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUserByIdResponse"/> class.
        /// </summary>
        public SecurityStoreGetUserByIdResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUserByIdResponse"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public SecurityStoreGetUserByIdResponse(UserData user)
        {
            this.User = user;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [MessageBodyMember]
        public UserData User
        {
            get;
            set;
        }

        #endregion
    }
}
