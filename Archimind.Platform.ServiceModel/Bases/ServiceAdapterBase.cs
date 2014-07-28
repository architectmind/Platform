using System;
using Archimind.Platform.Core;
using Archimind.Platform.Core.Exceptions;

namespace Archimind.Platform.ServiceModel
{
    /// <summary>
    /// Represents a base implementation for a service adapter.
    /// </summary>
    public class ServiceAdapterBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAdapterBase" /> class.
        /// </summary>
        public ServiceAdapterBase()
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exceptionToHandle">The exception to handle.</param>
        /// <param name="exceptionToThrow">The exception to throw.</param>
        /// <returns>True if we need to rethrow the exception.</returns>
        protected bool HandleException(Exception exceptionToHandle, out Exception exceptionToThrow)
        {
            return
                ExceptionHandler.ApplyPolicy(
                    exceptionToHandle,
                    LogicalLayer.ServiceLayer,
                    out exceptionToThrow);
        }

        #endregion
    }
}
