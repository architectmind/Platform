using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents a list o user data contracts.
    /// </summary>
    [CollectionDataContract(
        Name = "UserDataCollection",
        Namespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class UserDataCollection : List<UserData>
    {
    }
}
