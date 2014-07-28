using System;

namespace Archimind.Platform.Core.Internal
{
    /// <summary>
    /// Provides properties, methods, and events related to the current application.
    /// </summary>
    public static class Application
    {
        #region Members

        private static Microsoft.VisualBasic.ApplicationServices.ApplicationBase applicationBase
            = new Microsoft.VisualBasic.ApplicationServices.ApplicationBase();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the culture that the current thread uses for string manipulation and
        /// string formatting.
        /// </summary>
        public static System.Globalization.CultureInfo Culture
        {
            get
            {
                return applicationBase.Culture;
            }
        }

        /// <summary>
        /// Gets the invariant culture.
        /// </summary>
        public static System.Globalization.CultureInfo InvariantCulture
        {
            get
            {
                return System.Globalization.CultureInfo.InvariantCulture;
            }
        }

        /// <summary>
        /// Gets the culture that the current thread uses for retrieving culture-specific resources.
        /// </summary>
        public static System.Globalization.CultureInfo UICulture
        {
            get
            {
                return applicationBase.UICulture;
            }
        }

        #endregion
    }
}
