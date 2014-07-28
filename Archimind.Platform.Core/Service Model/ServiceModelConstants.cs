using System;

namespace Archimind.Platform.Core.ServiceModel
{
    /// <summary>
    /// Helper class to provide service model constants.
    /// </summary>
    public static class ServiceModelConstants
    {
        #region Constants

        /// <summary>
        /// Defines the default namespace for the Framework services.
        /// </summary>
        /// <remarks>This value should be used in all services provided by the framework.</remarks>
        public const string ServiceDefaultNamespace = "http://Archimind.Platform.Schemas/2014/v1/";

        /// <summary>
        /// The service security token
        /// </summary>
        public const string ServiceSecurityToken = "abc";

        #endregion
    }
}
