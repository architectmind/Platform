using System;
using System.Runtime.Serialization;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Exceptions
{
    /// <summary>
    /// Represents the fault contract of an error handled by the service layer.
    /// </summary>
    [DataContract(Namespace = ServiceModelConstants.ServiceDefaultNamespace, Name = "ServiceHandledFault")]
    public class ServiceHandledFault
    {
        #region Properties

        /// <summary>
        /// Gets or sets the inner error message.
        /// </summary>
        /// <value>The inner error message.</value>
        [DataMember(IsRequired = true, Name = "InnerErrorMessage", Order = 1)]
        public string InnerErrorMessage
        {
            get;
            set;
        }

        #endregion
    }
}
