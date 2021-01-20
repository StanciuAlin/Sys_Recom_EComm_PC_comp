using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid PaymentID { get; set; }
        public Guid ShipperID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
