using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class UserBranchOffice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int BranchOfficeId { get; set; }
        public virtual BranchOffice BranchOffice { get; set; }
    }
}
