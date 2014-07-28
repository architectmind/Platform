using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service UpdateUser request message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreUpdateUserRequest",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreUpdateUserRequest : RequestMessageContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreUpdateUserRequest"/> class.
        /// </summary>
        public SecurityStoreUpdateUserRequest()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreUpdateUserRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        public SecurityStoreUpdateUserRequest(string securityToken)
            : base(securityToken)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreUpdateUserRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        /// <param name="user">The user.</param>
        public SecurityStoreUpdateUserRequest(string securityToken, UserData user)
            : base(securityToken)
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
