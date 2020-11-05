using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class Review
    {
        public Guid ReviewID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public int Stars { get; set; }
        public Product Product { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
