using System;

namespace Archimind.Platform.Patterns
{
    /// <summary>
    /// Represents the interface to manipulate object state.
    /// </summary>
    public interface IObjectState
    {
        /// <summary>
        /// Gets or sets the state of the object.
        /// </summary>
        /// <value>
        /// The state of the object.
        /// </value>
        ObjectState ObjectState
        {
            get;
            set;
        }
    }
}
