using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RankUserProfile { get; set; }
        public Review Review { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
