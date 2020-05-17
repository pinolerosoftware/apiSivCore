using System;
using System.Collections.Generic;
using System.Text;

namespace Dto
{
    public class CategoryDtoInput
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int tenantId { get; set; }
    }

    public class CategoryDtoOutput
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int tenantId { get; set; }
        public Guid RowCode { get; set; }
        public DateTime? createAt { get; set; }
        public DateTime? updateAt { get; set; }
        public DateTime? deleteAt { get; set; }
        public int userCreated { get; set; }
        public bool active { get; set; }
    }
}
