using System;
using System.Text;
using Archimind.Platform.Core.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Archimind.Platform.Core.Exceptions
{
    /// <summary>
    /// Helper class for exceptions handling.
    /// </summary>
    public static class ExceptionHandler
    {
        #region Constants

        /// <summary>
        /// The handling instance token.
        /// </summary>
        private const string HandlingInstanceToken = "{handlingInstanceID}";

        #endregion

        #region Public Methods

        /// <summary>
        /// Formats the exception message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="handlingInstanceId">The handling instance identifier.</param>
        /// <returns>The exception message.</returns>
        /// <exception cref="System.ArgumentNullException">If message is null or empty.</exception>
        public static string FormatExceptionMessage(string message, Guid handlingInstanceId)
        {
            if (Strings.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message");
            }
            else
            {
                return
                    message.Replace(
                        HandlingInstanceToken,
                        handlingInstanceId.ToString());
            }
        }

        /// <summary>
        /// Returns an exception message that is composed by the specified message and the inner exception message.
        /// </summary>
        /// <param name="message">The base exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>An exception message that is composed by the specified message and the inner exception message.</returns>
        public static string ComposeExceptionMessage(string message, Exception innerException)
        {
            // Default result

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(message);

            // Append inner exception message (if not in production mode)

            if (innerException != null)
            {
                if (!string.IsNullOrEmpty(innerException.Message))
                {
                    sb.AppendLine(innerException.Message);
                }
            }

            // Result

            return sb.ToString();
        }

        /// <summary>
        /// Applies the policy.
        /// </summary>
        /// <param name="exceptionToHandle">The exception to handle.</param>
        /// <param name="logicalLayer">The logical layer.</param>
        /// <param name="exceptionToThrow">The exception to throw.</param>
        /// <returns>A boolean value indicating if we need to rethrow the exception.</returns>
        public static bool ApplyPolicy(Exception exceptionToHandle, LogicalLayer logicalLayer, out Exception exceptionToThrow)
        {
            return
                ExceptionPolicy.HandleException(
                    exceptionToHandle, 
                    GetPolicyName(logicalLayer), 
                    out exceptionToThrow);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the name of the policy.
        /// </summary>
        /// <param name="logicalLayer">The logical layer.</param>
        /// <returns>The logical layer name.</returns>
        /// <exception cref="System.InvalidOperationException">Unknown logical layer.</exception>
        private static string GetPolicyName(LogicalLayer logicalLayer)
        {
            switch (logicalLayer)
            {
                case LogicalLayer.DataLayer:
                    return "DataLayer";
                case LogicalLayer.BusinessLayer:
                    return "BusinessLayer";
                case LogicalLayer.ServiceLayer:
                    return "ServiceLayer";
                case LogicalLayer.PresentationLayer:
                    return "PresentationLayer";
                default:
                    throw new InvalidOperationException(Properties.Resources.RES_UnknownLogicalLayer);
            }
        }

        #endregion
    }
}
