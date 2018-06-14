using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using Service_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        public ProductService()
        {
            this.productRepository = new Repository<Product>();
        }
        public void AddProduct(Product product)
        {
            productRepository.Add(product);
        }

        public void Delete(int id)
        {
            Product product = GetProduct(id);
            productRepository.Delete(product);
            productRepository.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return productRepository.Get(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }
    }
}
