using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service UpdateUser response message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreUpdateUserResponse",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreUpdateUserResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreUpdateUserResponse"/> class.
        /// </summary>
        public SecurityStoreUpdateUserResponse()
        {
        }

        #endregion
    }
}
