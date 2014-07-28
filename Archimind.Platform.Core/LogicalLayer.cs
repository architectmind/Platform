using System;

namespace Archimind.Platform.Core
{
    /// <summary>
    /// Defines the logical layer of the platform architecture.
    /// </summary>
    public enum LogicalLayer
    {
        /// <summary>
        /// Data layer.
        /// </summary>
        DataLayer = 0,

        /// <summary>
        /// Business logic layer.
        /// </summary>
        BusinessLayer = 1,

        /// <summary>
        /// Service layer.
        /// </summary>
        ServiceLayer = 2,

        /// <summary>
        /// Presentation layer.
        /// </summary>
        PresentationLayer = 4
    }
}
