using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using Archimind.Platform.Core.Exceptions;
using Archimind.Platform.Core.Internal;
using Archimind.Platform.Core.Text;
using Archimind.Platform.DataModel.Services;
using Archimind.Platform.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;

namespace Archimind.Platform.DataModel.Exceptions
{
    /// <summary>
    /// Exception Handler for the data layer. Replaces the exceptions with a DataModelException.
    /// </summary>
    [ConfigurationElementType(typeof(CustomHandlerData))]
    public class DataLayerExceptionHandler : IExceptionHandler
    {
        #region Members

        private NameValueCollection attributes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLayerExceptionHandler"/> class.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        public DataLayerExceptionHandler(NameValueCollection attributes)
        {
            this.attributes = attributes;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// When implemented by a class, handles an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="exception">The exception to handle.</param>
        /// <param name="handlingInstanceId">The unique ID attached to the handling chain for this handling instance.</param>
        /// <returns>
        /// Modified exception to pass to the next exceptionHandlerData in the chain.
        /// </returns>
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            // Build de exception message.

            string message =
                ExceptionHandler.ComposeExceptionMessage(
                    ExceptionHandler.FormatExceptionMessage(Properties.Resources.RES_DataLayerExceptionHandlerMessage, handlingInstanceId),
                    exception);
            
            // Check if it is a RepositoryException.

            RepositoryException repositoryException = exception as RepositoryException;
            if (repositoryException != null)
            {
                // Log the repository exception.

                PlatformEventSource.Log.RepositoryError(message);

                // Wrap and return.

                return
                    new DataModelException(message, repositoryException);
            }

            // Log the general exception.

            PlatformEventSource.Log.GeneralError(message);

            // Wrap and return.

            return
                new DataModelException(message, exception);
        }

        #endregion
    }
}
