using System;
using System.ComponentModel;

namespace Archimind.Platform.BusinessEntities
{
    /// <summary>
    /// Notifies clients of operations performed on a business entity.
    /// </summary>
    public interface IBusinessEntity : INotifyPropertyChanged
    {
        #region Events

        #region CRUD Events

        /// <summary>
        /// Occurs before a business entity is created or updated.
        /// </summary>
        event EventHandler<UpdatingEventArgs> Updating;

        /// <summary>
        /// Occurs after a business entity is created or updated.
        /// </summary>
        event EventHandler<UpdatedEventArgs> Updated;

        /// <summary>
        /// Occurs before a business entity is deleted.
        /// </summary>
        event EventHandler<DeletingEventArgs> Deleting;

        /// <summary>
        /// Occurs after a business entity is deleted.
        /// </summary>
        event EventHandler<DeletedEventArgs> Deleted;

        /// <summary>
        /// Occurs after a business entity is read.
        /// </summary>
        event EventHandler<ReadEventArgs> Read;

        #endregion

        #endregion
    }
}
