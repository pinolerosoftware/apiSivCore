using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BranchOffice : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// Phone format (+505 7651-2122)
        /// </summary>
        public string Phone { get; set; }

    }
}
