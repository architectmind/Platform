using System;

namespace Archimind.Platform.Patterns
{
    /// <summary>
    /// Represents the entity state values.
    /// </summary>
    public enum ObjectState
    {
        /// <summary>
        /// The new state.
        /// </summary>
        New,

        /// <summary>
        /// The clean state.
        /// </summary>
        Clean,

        /// <summary>
        /// The dirty state.
        /// </summary>
        Dirty,

        /// <summary>
        /// The removed state.
        /// </summary>
        Removed
    }
}
