using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Dtos
{
    public class EntityDto
    {
        public Guid Id { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
