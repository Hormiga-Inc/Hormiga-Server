using Catalog.Core.Contracts;
using System;

namespace Catalog.Core.Entities
{
    public class Catalog : IEntity
    {
        public Catalog()
        {
            this.Id = new Guid();
            this.CreatedAt = DateTime.UtcNow;

        }
        public Guid Id { get; set;}

        public DateTime CreatedAt { get; }

        public DateTime ModifiedAt { get; set; }
    }
}
