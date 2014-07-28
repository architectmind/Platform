using System;
using System.Runtime.Serialization;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents a user credential data contract.
    /// </summary>
    [DataContract(
        Name = "UserData",
        Namespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class CredentialData : DataContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialData"/> class.
        /// </summary>
        public CredentialData()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialData"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public CredentialData(string id)
            : base(id)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DataMember(Order = 2)]
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [DataMember(Order = 3)]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [windows authentication].
        /// </summary>
        /// <value>
        /// <c>true</c> if [windows authentication]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Order = 4)]
        public bool WindowsAuthentication
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the network domain.
        /// </summary>
        /// <value>
        /// The network domain.
        /// </value>
        [DataMember(Order = 5)]
        public string NetworkDomain
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        [DataMember(Order = 6)]
        public DateTime ExpirationDate
        {
            get;
            set;
        }

        #endregion

    }
}
