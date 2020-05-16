using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public Guid RowCode { get; set; }
        public int UserCreated { get; set; }
    }
}
