using System;

namespace Archimind.Platform.Patterns
{
    /// <summary>
    /// Represents the base interface for a entity.
    /// </summary>
    /// <typeparam name="TSurrogateKey">The type of the surrogate key.</typeparam>
    /// <typeparam name="TNaturalKey">The type of the natural key.</typeparam>
    public interface IEntity<TSurrogateKey, TNaturalKey> : IObjectState, IEquatable<IEntity<TSurrogateKey, TNaturalKey>>
    {
        /// <summary>
        /// Gets or sets the surrogate key.
        /// </summary>
        /// <value>
        /// The surrogate key.
        /// </value>
        TSurrogateKey SurrogateKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the natural key.
        /// </summary>
        /// <value>
        /// The natural key.
        /// </value>
        TNaturalKey NaturalKey
        {
            get;
            set;
        }
    }
}
