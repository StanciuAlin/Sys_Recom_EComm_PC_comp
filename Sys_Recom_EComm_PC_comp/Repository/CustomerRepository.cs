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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Order> GetOrdersByUser(Guid id)
        {
            return dbContext.Orders
                            .Where(order => order.CustomerID == id)
                            .Include(order => order.ProductID)
                            .AsEnumerable();
        }

        public Customer GetUserByGuid(Guid id)
        {
            Customer foundUser = dbContext.Customers
                            .Where(user => user.CustomerID == id)
                            .SingleOrDefault();

            return foundUser;
        }

        public Customer GetUserByUserId(Guid userId)
        {
            Customer foundUser = dbContext.Customers
                            .Where(user => user.CustomerID == userId)
                            .SingleOrDefault();

            return foundUser;
        }
    }
}
