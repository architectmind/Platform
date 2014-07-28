using System;
using Archimind.Platform.Core;
using Archimind.Platform.Core.Exceptions;
using Archimind.Platform.DataModel.Services;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Archimind.Platform.DataModel
{
    /// <summary>
    /// Represents a facade for the data model services.
    /// </summary>
    public class DataModelManager : DataModelServiceBase, IDisposable
    {
        #region Members
        
        private ISecurityStoreRepository securityStoreRepository;
        private bool disposed = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelManager"/> class.
        /// </summary>
        public DataModelManager()
        {
            this.securityStoreRepository = new SecurityStoreRepository();
        }

        #endregion

        #region Finalizer

        /// <summary>
        /// Finalizes an instance of the <see cref="DataModelManager"/> class.
        /// </summary>
        ~DataModelManager()
        {
            Dispose(false);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the security store.
        /// </summary>
        /// <value>
        /// The security store.
        /// </value>
        public ISecurityStoreRepository SecurityStoreRepository
        {
            get { return this.securityStoreRepository; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
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
                    this.securityStoreRepository.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
