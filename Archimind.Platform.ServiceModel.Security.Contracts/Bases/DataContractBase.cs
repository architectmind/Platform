using System;
using System.Runtime.Serialization;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents a base class for data contracts.
    /// </summary>
    [DataContract(
        Name = "DataContractBase", 
        Namespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class DataContractBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContractBase"/> class.
        /// </summary>
        public DataContractBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContractBase"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public DataContractBase(string id)
        {
            this.Id = id;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Order = 1)]
        public string Id
        {
            get;
            set;
        }

        #endregion
    }
}
