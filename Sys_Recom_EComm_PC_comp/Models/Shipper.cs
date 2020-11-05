using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class Shipper
    {
        public Guid ShipperID { get; set; }
        public double Price { get; set; }
        public string DeliveryTime { get; set; }
        public Guid CompanyID { get; set; }
    }
}
