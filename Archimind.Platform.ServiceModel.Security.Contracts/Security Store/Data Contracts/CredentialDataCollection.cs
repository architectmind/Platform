using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Archimind.Platform.Core.ServiceModel;

namespace Archimind.Platform.ServiceModel.Security.Contracts
{
    /// <summary>
    /// Represents a list o user credential data contracts.
    /// </summary>
    [CollectionDataContract(
        Name = "CredentialDataCollection",
        Namespace = ServiceModelConstants.ServiceDefaultNamespace)]
    public class CredentialDataCollection : List<CredentialData>
    {
    }
}
