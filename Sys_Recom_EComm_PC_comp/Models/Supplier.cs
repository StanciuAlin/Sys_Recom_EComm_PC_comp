using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class Supplier
    {
        public Guid SupplierID { get; set; }
        public string ProductionTime { get; set; }
        public string Description { get; set; }
        public Guid CompanyID { get; set; }
    }
}
