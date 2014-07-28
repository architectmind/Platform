using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service DeleteUser response message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreDeleteUserResponse",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreDeleteUserResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreDeleteUserResponse"/> class.
        /// </summary>
        public SecurityStoreDeleteUserResponse()
        {
        }

        #endregion
    }
}
