using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service GetUsers request message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreGetUsersRequest",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreGetUsersRequest : RequestMessageContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersRequest"/> class.
        /// </summary>
        public SecurityStoreGetUsersRequest()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        public SecurityStoreGetUsersRequest(string securityToken)
            : base(securityToken)
        {
        }

        #endregion
    }
}
