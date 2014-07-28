using System;
using System.Runtime.Serialization;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents a user data contract.
    /// </summary>
    [DataContract(
        Name = "UserData",
        Namespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class UserData : DataContractBase
    {
        #region Members

        private CredentialDataCollection credentials;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        public UserData()
            : base()
        {
            this.credentials = new CredentialDataCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public UserData(string id)
            : base(id)
        {
            this.credentials = new CredentialDataCollection();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Order = 2)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember(Order = 3)]
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [DataMember(Order = 4)]
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember(Order = 5)]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the credentials.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        [DataMember(Order = 6)]
        public CredentialDataCollection Credentials
        {
            get { return this.credentials; }
            set { this.credentials = value; }
        }

        #endregion
    }
}
