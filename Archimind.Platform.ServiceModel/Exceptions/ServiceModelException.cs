using System;
using System.Runtime.Serialization;
using Archimind.Platform.Core.Exceptions;

namespace Archimind.Platform.ServiceModel.Exceptions
{
    /// <summary>
    /// Represents a Service Model Layer Exception.
    /// </summary>
    [Serializable]
    public class ServiceModelException : KnownApplicationException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModelException"/> class.
        /// </summary>
        public ServiceModelException()
            : base(Properties.Resources.RES_ServiceModelError)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModelException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServiceModelException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModelException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected ServiceModelException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModelException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ServiceModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
