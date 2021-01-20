using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class Interaction
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid CustomerID { get; set; }

        public static Interaction Create(Guid productID, DateTime timestamp, Guid customerID)
        {
            var newInteraction = new Interaction()
            {
                Id = Guid.NewGuid(),
                ProductID = productID,
                Timestamp = timestamp,
                CustomerID = customerID
            };
            return newInteraction;
        }
    }
}
