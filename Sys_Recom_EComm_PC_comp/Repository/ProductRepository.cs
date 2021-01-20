using Microsoft.EntityFrameworkCore;
using Sys_Recom_EComm_PC_comp.Data;
using Sys_Recom_EComm_PC_comp.Interfaces;
using Sys_Recom_EComm_PC_comp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products
                .Include(product => product.Name)
                .AsEnumerable();
        }

        public Product GetProduct(Guid guid)
        {
            return dbContext.Products
                .Include(product => product.Name)
                .Where(product => product.ProductID == guid)
                .SingleOrDefault();
        }

        public ICollection<Order> GetProductOrders(Guid guid)
        {
            IEnumerable<Order> productOrders = dbContext.Orders
                .Include(order => order.ProductID)
                .Where(order => order.ProductID == guid)
                .AsEnumerable();

            return productOrders.ToList();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
