using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public Guid RowCode { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public int UserCreated { get; set; }
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public bool Active { get; set; }
    }
}
