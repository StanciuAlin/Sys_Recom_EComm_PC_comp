using Sys_Recom_EComm_PC_comp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
        ICollection<Order> GetProductOrders(Guid guid);
        Product GetProduct(Guid guid);
    }
}
