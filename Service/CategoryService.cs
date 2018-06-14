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
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categoryRepository;
        private IRepository<Product> productRepository;
        public CategoryService()
        {
            this.categoryRepository = new Repository<Category>();
        }

        public void AddCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public void DeleteCategory(int id)
        {
            Product product = productRepository.Get(id);
            productRepository.Remove(product);
            Category category = GetCategory(id);
            categoryRepository.Remove(category);
            categoryRepository.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
           return categoryRepository.Get(id);
        }

        public void UpdateUser(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
