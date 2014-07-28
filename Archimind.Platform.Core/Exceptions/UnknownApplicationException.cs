using System;
using System.Runtime.Serialization;

namespace Archimind.Platform.Core.Exceptions
{
    /// <summary>
    /// Represents unexpected errors that can occur.
    /// </summary>
    /// <remarks>All exceptions that applications shouldn't handle gracefully, must derive from this base class.</remarks>
    [Serializable]
    public class UnknownApplicationException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownApplicationException"/> class.
        /// </summary>
        public UnknownApplicationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownApplicationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnknownApplicationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownApplicationException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected UnknownApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownApplicationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public UnknownApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
