using System;
using Archimind.Platform.DataModel;

namespace Archimind.Platform.BusinessModel
{
    /// <summary>
    /// Represents a base class for any business model service.
    /// </summary>
    public abstract class BusinessModelServiceBase : IBusinessModelServiceBase
    {
        #region Members

        /// <summary>
        /// The data model manager.
        /// </summary>
        protected DataModelManager dataModelManager;
        private bool disposed = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessModelServiceBase"/> class.
        /// </summary>
        public BusinessModelServiceBase()
        {
            this.dataModelManager = new DataModelManager();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessModelServiceBase"/> class.
        /// </summary>
        /// <param name="dataModelManager">The data model manager.</param>
        /// <exception cref="System.ArgumentNullException">The parameter dataModelManager.</exception>
        public BusinessModelServiceBase(DataModelManager dataModelManager)
        {
            if (dataModelManager == null)
            {
                throw new ArgumentNullException("dataModelManager");
            }

            this.dataModelManager = dataModelManager;
        }

        #endregion

        #region Finalizer

        /// <summary>
        /// Finalizes an instance of the <see cref="BusinessModelServiceBase"/> class.
        /// </summary>
        ~BusinessModelServiceBase()
        {
            Dispose(false);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dataModelManager.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
