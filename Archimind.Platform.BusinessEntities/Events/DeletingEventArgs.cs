using System;

namespace Archimind.Platform.BusinessEntities
{
    /// <summary>
    /// Provides data for the IBusinessEntityEvents.Deleting event.
    /// </summary>
    public class DeletingEventArgs : EventArgs
    {
        #region Members

        private bool cancel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DeletingEventArgs"/> is cancel.
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
