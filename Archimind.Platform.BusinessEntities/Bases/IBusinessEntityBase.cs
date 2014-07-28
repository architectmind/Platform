using System;
using Archimind.Platform.Patterns;

namespace Archimind.Platform.BusinessEntities
{
    /// <summary>
    /// Defines the public interface of a business entity base.
    /// </summary>
    public interface IBusinessEntityBase : IEntity<Guid, string>
    {
    }
}
