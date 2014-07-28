using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service CreateUser response message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreCreateUserResponse",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreCreateUserResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreCreateUserResponse"/> class.
        /// </summary>
        public SecurityStoreCreateUserResponse()
        {
        }

        #endregion
    }
}
