using Sys_Recom_EComm_PC_comp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetUserByGuid(Guid id);
        Customer GetUserByUserId(Guid userId);
        IEnumerable<Order> GetOrdersByUser(Guid id);
    }
}
