using Sys_Recom_EComm_PC_comp.Interfaces;
using Sys_Recom_EComm_PC_comp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Services
{
    public class ProductService
    {

        private readonly IProductRepository productRepository;
        private readonly IInteractionRepository interactionRepository;

        public ProductService(IProductRepository productRepository, IInteractionRepository interactionRepository)
        {
            this.productRepository = productRepository;
            this.interactionRepository = interactionRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAllProducts();
        }

        public IEnumerable<Product> GetTrending()
        {
            IEnumerable<Product> products = GetAll();
            Dictionary<Product, double> productScore = new Dictionary<Product, double>();

            double orderWeight = 3;
            double clickWeight = 1;
            double trendingAmount = 5;
            double gravity = 0.3;

            foreach (Product product in products)
            {

                double orderDecay = 0;
                foreach (var order in GetProductOrders(product.ProductID))
                {
                    double days = (DateTime.UtcNow - order.TransactionDate).TotalDays;
                    orderDecay += days * gravity;
                }

                double clickDecay = 0;
                foreach (var interaction in GetInteractions(product.ProductID))
                {
                    double days = (DateTime.UtcNow - interaction.Timestamp).TotalDays;
                    clickDecay += days * gravity;
                }

                double orderCount = GetProductOrders(product.ProductID).Count;
                double clickCount = GetInteractions(product.ProductID).Count;

                double orderScore = orderCount * orderWeight / (orderDecay / (orderCount + 1));
                double clickScore = clickCount * clickWeight / (clickDecay / (clickCount + 1));

                double score = orderScore + clickScore;

                productScore.Add(product, score);
            }

            var orderedScores = productScore.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            List<Product> trendingBooks = new List<Product>();

            for (int i = 0; i < trendingAmount; i++)
            {
                trendingBooks.Add(orderedScores.ElementAt(i).Key);
            }

            return trendingBooks.AsEnumerable();
        }

        public ICollection<Interaction> GetInteractions(Guid guid)
        {
            List<Interaction> productInteractions = new List<Interaction>();

            foreach (Interaction interaction in interactionRepository.GetAll())
            {
                if (interaction.ProductID == guid)
                {
                    productInteractions.Add(interaction);
                }
            }

            return productInteractions;
        }

        public ICollection<Order> GetProductOrders(Guid guid)
        {
            return productRepository.GetProductOrders(guid);
        }

        public Product GetProduct(Guid productID)
        {
            return productRepository.GetProduct(productID);
        }

    }
}
