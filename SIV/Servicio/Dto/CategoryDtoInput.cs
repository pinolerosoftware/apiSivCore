using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dto
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
    }
}
