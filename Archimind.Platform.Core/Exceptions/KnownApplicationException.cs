using System;
using System.Runtime.Serialization;

namespace Archimind.Platform.Core.Exceptions
{
    /// <summary>
    /// Represents expected errors that can occur.
    /// </summary>
    /// <remarks>
    /// All exceptions that applications should handle gracefully, must derive from this base class.
    /// </remarks>
    [Serializable]
    public class KnownApplicationException : Exception
    {
        #region Fields

        private bool exceptionIsKnown = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownApplicationException"/> class.
        /// </summary>
        public KnownApplicationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownApplicationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public KnownApplicationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownApplicationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exceptionIsKnown">If set to <c>true</c> [exception is known].</param>
        public KnownApplicationException(string message, bool exceptionIsKnown)
            : base(message)
        {
            this.exceptionIsKnown = exceptionIsKnown;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownApplicationException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <exception cref="System.ArgumentNullException">The info.</exception>
        protected KnownApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.exceptionIsKnown = info.GetBoolean("IsKnownException");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownApplicationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public KnownApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the exception is a known exception.
        /// </summary>
        public bool IsKnownException
        {
            get { return this.exceptionIsKnown; }
            set { this.exceptionIsKnown = value; }
        }

        /// <summary>
        /// Gets the instance type.
        /// </summary>
        /// <value>The instance type.</value>
        public string TypeFullName
        {
            get { return this.GetType().FullName; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// When overridden in a base class, sets the SerializationInfo with information about the exception.
        /// </summary>
        /// <param name="info">The SerializationInfo that contains information about the exception.</param>
        /// <param name="context">Contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            base.GetObjectData(info, context);
            info.AddValue("IsKnownException", this.exceptionIsKnown);
        }

        #endregion
    }
}
