using Archimind.Platform.Core;
using Archimind.Platform.Core.Exceptions;
using System;

namespace Archimind.Platform.DataModel
{
    /// <summary>
    /// Represents a base class for any data model service.
    /// </summary>
    public abstract class DataModelServiceBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelServiceBase"/> class.
        /// </summary>
        public DataModelServiceBase()
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
                    LogicalLayer.DataLayer,
                    out exceptionToThrow);
        }

        #endregion
    }
}
