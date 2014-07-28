using System;
using System.Collections.Specialized;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Archimind.Platform.Core.Exceptions;
using Archimind.Platform.Core.Internal;

namespace Archimind.Platform.ServiceModel.Exceptions
{
    /// <summary>
    /// Default exception handler for the service model logical layer.
    /// </summary>
    /// <remarks>
    /// This an exception handler compatible with the Microsoft Enterprise
    /// Library Exception Handling block.
    /// </remarks>
    [ConfigurationElementType(typeof(CustomHandlerData))]
    public class ServiceLayerExceptionHandler : IExceptionHandler
    {
        #region Members

        private NameValueCollection attributes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLayerExceptionHandler"/> class.
        /// </summary>
        /// <param name="attributes">Configuration custom attributes.</param>
        public ServiceLayerExceptionHandler(NameValueCollection attributes)
        {
            this.attributes = attributes;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles one exception in the Exception Handling Application Block handlers chain.
        /// </summary>
        /// <param name="exception">The exception to handle.</param>
        /// <param name="handlingInstanceId">The unique ID attached to the handling chain for this handling instance.</param>
        /// <returns>
        /// The exception after handling.
        /// </returns>
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            // Behavior:
            //
            // If exception is KnownApplicationException -> Log (handled errors), return Fault with inner error message
            // If exception is Exception -> Log (unhandled errors), return Fault with generic inner error message (shielding)

            ServiceHandledFault serviceFault = new ServiceHandledFault();

            // KnownApplicationException

            KnownApplicationException knownException = (exception as KnownApplicationException);
            if (knownException != null)
            {
                serviceFault.InnerErrorMessage = knownException.InnerException != null ? knownException.InnerException.Message : knownException.Message;
                return new FaultException<ServiceHandledFault>(
                    serviceFault, 
                    new FaultReason(
                        new FaultReasonText(serviceFault.InnerErrorMessage, Application.UICulture)));
            }

            // Exception

            string message = Properties.Resources.RES_ServiceUnknownExceptionMessage;
            serviceFault.InnerErrorMessage = message;
            return new FaultException<ServiceHandledFault>(
                serviceFault, new FaultReason(
                    new FaultReasonText(serviceFault.InnerErrorMessage, Application.UICulture)));
        }

        /// <summary>
        /// Handles any fault exception raised by the service layer and translates it into a known application exception.
        /// If the exception is not a fault exception that it will not be touched.
        /// </summary>
        /// <param name="exception">The original exception.</param>
        /// <returns>Returns a know exception corresponding to the input fault exception.</returns>
        public static Exception HandleFaultException(Exception exception)
        {
            // Translate service handled faults to know exceptions

            FaultException serviceFault = exception as FaultException;
            if (serviceFault != null)
            {
                return new KnownApplicationException(serviceFault.Message, serviceFault.InnerException);
            }

            // Default result

            return exception;
        }

        #endregion
    }
}
