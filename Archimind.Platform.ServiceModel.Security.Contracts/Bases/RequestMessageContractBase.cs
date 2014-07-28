using System;
using System.ServiceModel;
using System.Net.Security;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Base class for request message contracts.
    /// </summary>
    /// <remarks>All message contracts used in requests should derive from this base class.</remarks>
    [MessageContract(
        WrapperName = "RequestMessageContractBase", 
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class RequestMessageContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestMessageContractBase"/> class.
        /// </summary>
        public RequestMessageContractBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestMessageContractBase"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        public RequestMessageContractBase(string securityToken)
        {
            this.SecurityToken = securityToken;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the security token.
        /// </summary>
        /// <value>
        /// The security token.
        /// </value>
        [MessageHeader(
            ProtectionLevel = ProtectionLevel.None)]
        public string SecurityToken
        {
            get;
            set;
        }

        #endregion
    }
}
