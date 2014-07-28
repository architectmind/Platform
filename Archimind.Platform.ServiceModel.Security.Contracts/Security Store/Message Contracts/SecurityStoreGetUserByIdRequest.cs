using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service GetUserById request message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreGetUserByIdRequest",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreGetUserByIdRequest : RequestMessageContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUserByIdRequest"/> class.
        /// </summary>
        public SecurityStoreGetUserByIdRequest()
            :base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUserByIdRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        public SecurityStoreGetUserByIdRequest(string securityToken)
            : base(securityToken)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUserByIdRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        /// <param name="id">The identifier.</param>
        public SecurityStoreGetUserByIdRequest(string securityToken, string id)
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
