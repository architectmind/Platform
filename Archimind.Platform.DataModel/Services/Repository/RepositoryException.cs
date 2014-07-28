using System;
using System.Runtime.Serialization;
using Archimind.Platform.Core.Exceptions;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents unexpected errors that can occur when executing repository operations.
    /// </summary>
    [Serializable]
    public class RepositoryException : KnownApplicationException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryException"/> class.
        /// </summary>
        public RepositoryException()
            : base(Properties.Resources.RES_RepositoryError)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RepositoryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected RepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
