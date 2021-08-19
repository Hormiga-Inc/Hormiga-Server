using Catalog.Core.Contracts;
using System;

namespace Catalog.Core.Entities
{
    public class Catalog : IEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
