using System;

namespace Archimind.Platform.BusinessEntities
{
    /// <summary>
    /// Provides data for IBusinessEntityEvents.Updated event.
    /// </summary>
    public class UpdatedEventArgs : EventArgs
    {
        #region Members

        private bool wasNew;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="wasNew">Indicates if the business entity didn't exist before it was updated.</param>
        public UpdatedEventArgs(bool wasNew)
        {
            this.wasNew = wasNew;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the business entity didn't exist before it was updated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [was new]; otherwise, <c>false</c>.
        /// </value>
        public bool WasNew
        {
            get { return this.wasNew; }
        }

        #endregion
    }
}
