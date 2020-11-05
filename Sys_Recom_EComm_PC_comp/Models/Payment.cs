using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public string PaymentType { get; set; }
        public double Amount { get; set; }
    }
}
