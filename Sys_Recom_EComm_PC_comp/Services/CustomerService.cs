using Sys_Recom_EComm_PC_comp.Interfaces;
using Sys_Recom_EComm_PC_comp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IProductRepository bookRepository;
        private readonly IInteractionRepository interactionRepository;

        public CustomerService(ICustomerRepository customerRepository, IProductRepository bookRepository,
            IInteractionRepository interactionRepository)
        {
            this.customerRepository = customerRepository;
            this.bookRepository = bookRepository;
            this.interactionRepository = interactionRepository;
        }

        public Customer RegisterNewUser(Guid customerID, string name, string address, string phone, string email,
            int rankUserProfile)
        {
            var newUser = Customer.Create(customerID, name, address, phone, email, rankUserProfile);
            newUser = customerRepository.Add(newUser);
            customerRepository.Update(newUser);
            return newUser;
        }

        public Customer RegisterClick(Guid productID, DateTime timestamp, Guid customerID)
        {
            var newInteraction = Interaction.Create(productID, timestamp, customerID);

            var customer = customerRepository.GetUserByGuid(customerID);
            interactionRepository.Add(newInteraction);

            customer.AddInteraction(newInteraction);
            customerRepository.Update(customer);

            return customer;
        }

        public Customer GetUserByGuid(Guid id)
        {
            return customerRepository.GetUserByGuid(id);
        }

        public Customer GetUserByUserId(Guid userId)
        {
            return customerRepository.GetUserByUserId(userId);
        }
    }
}
