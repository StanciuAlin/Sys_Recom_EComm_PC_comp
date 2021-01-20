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
        public IList<Interaction> Interactions { get; set; }
        public Review Review { get; set; }
        public ICollection<Order> Orders { get; set; }

        public static Customer Create(Guid customerID, string name, string address, string phone, string email,
            int rankUserProfile)
        {
            var newUser = new Customer()
            {
                CustomerID = Guid.NewGuid(),
                Name = name,
                Address = address,
                Phone = phone,
                Email = email,
                RankUserProfile = rankUserProfile,
                Interactions = new List<Interaction>(),
                Orders = new List<Order>()
            };
            return newUser;
        }

        public Customer AddInteraction(Interaction interaction)
        {
            if (Interactions == null)
            {
                Interactions = new List<Interaction>();
            }
            Interactions.Add(interaction);

            return this;
        }
    }
}
