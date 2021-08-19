using System;

namespace Catalog.Core.Contracts
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; }
        DateTime ModifiedAt { get; }
    }
}
