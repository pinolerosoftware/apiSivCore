using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class UserRol: IdentityRole
    {
        public string Description { get; set; }
    }
}
