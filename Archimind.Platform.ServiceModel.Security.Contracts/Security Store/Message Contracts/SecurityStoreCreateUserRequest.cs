using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service CreateUser request message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreCreateUserRequest",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreCreateUserRequest : RequestMessageContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreCreateUserRequest"/> class.
        /// </summary>
        public SecurityStoreCreateUserRequest()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreCreateUserRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        public SecurityStoreCreateUserRequest(string securityToken)
            : base(securityToken)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreCreateUserRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        /// <param name="user">The user.</param>
        public SecurityStoreCreateUserRequest(string securityToken, UserData user)
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
