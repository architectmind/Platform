using System;

namespace Archimind.Platform.BusinessEntities
{
    /// <summary>
    /// Provides data for IBusinessEntityEvents.Updating event.
    /// </summary>
    public class UpdatingEventArgs : EventArgs
    {
        #region Members

        private bool isNew;
        private bool cancel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatingEventArgs"/> class.
        /// </summary>
        /// <param name="isNew">Indicates if the business entity is going to be created or updated.</param>
        public UpdatingEventArgs(bool isNew)
        {
            this.isNew = isNew;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        public bool IsNew
        {
            get { return this.isNew; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UpdatingEventArgs"/> is cancel.
        /// </summary>
        /// <value>
        ///   <c>true</c> if cancel; otherwise, <c>false</c>.
        /// </value>
        public bool Cancel
        {
            get { return this.cancel; }
            set { this.cancel = value; }
        }

        #endregion
    }
}
