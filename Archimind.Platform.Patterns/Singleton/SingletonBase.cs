using System;

namespace Archimind.Platform.Patterns.Singleton
{
    /// <summary>
    /// Represents a base implementation for a singleton.
    /// </summary>
    public sealed class SingletonBase
    {
        #region Static Members

        private static volatile SingletonBase instance;
        private static object objectLockCheck = new Object();

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="SingletonBase"/> class from being created.
        /// </summary>
        private SingletonBase()
        {
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static SingletonBase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (objectLockCheck)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonBase();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion
    }
}
