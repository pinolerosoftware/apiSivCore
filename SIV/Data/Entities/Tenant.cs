using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SocialReazon { get; set; }
        public TypeBusiness TypeBusiness { get; set; }
    }
}
