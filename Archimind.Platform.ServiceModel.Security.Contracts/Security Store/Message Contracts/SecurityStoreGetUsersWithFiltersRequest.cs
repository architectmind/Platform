using System;
using System.ServiceModel;
using Archimind.Platform.Core.ServiceModel;
using Serialize.Linq.Nodes;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents the security store service GetUserWithFilters request message contract.
    /// </summary>
    [MessageContract(
        WrapperName = "SecurityStoreGetUsersWithFiltersRequest",
        WrapperNamespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class SecurityStoreGetUsersWithFiltersRequest : RequestMessageContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersWithFiltersRequest"/> class.
        /// </summary>
        public SecurityStoreGetUsersWithFiltersRequest()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreGetUsersWithFiltersRequest"/> class.
        /// </summary>
        /// <param name="securityToken">The security token.</param>
        public SecurityStoreGetUsersWithFiltersRequest(string securityToken)
            : base(securityToken)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the filter expression.
        /// </summary>
        /// <value>
        /// The filter expression.
        /// </value>
        [MessageBodyMember]
        public ExpressionNode FilterExpressionNode
        {
            get;
            set;
        }

        #endregion
    }
}
