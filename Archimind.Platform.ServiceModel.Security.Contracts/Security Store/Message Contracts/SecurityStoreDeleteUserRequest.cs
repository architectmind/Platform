using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service DeleteUser request message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreDeleteUserRequest",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreDeleteUserRequest : RequestMessageContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreDeleteUserRequest"/> class.
        /// </summary>
        public SecurityStoreDeleteUserRequest()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreDeleteUserRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        public SecurityStoreDeleteUserRequest(string securityToken)
            : base(securityToken)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreDeleteUserRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        /// <param name="id">The identifier.</param>
        public SecurityStoreDeleteUserRequest(string securityToken, string id)
            : base(securityToken)
        {
            this.Id = id;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [MessageBodyMember]
        public string Id
        {
            get;
            set;
        }

        #endregion
    }
}
