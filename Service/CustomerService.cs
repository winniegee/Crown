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
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> customerRepository;
        private IRepository<Order> orderRepository;
        public CustomerService()
        {
            this.customerRepository = new Repository<Customer>();
            this.orderRepository = new Repository<Order>();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepository.GetAll();
        }

        public void AddCustomer(Customer customer)
        {
            customerRepository.Add(customer);
        }
        public void Update(Customer customer)
        {
            customerRepository.Update(customer);
        }

        public Customer GetCustomer(int id)
        {
            return customerRepository.Get(id);
        }
        public void DeleteCustomer(int id)
        {
            Order order = orderRepository.Get(id);
            orderRepository.Remove(order);
            Customer customer = GetCustomer(id);
            customerRepository.Remove(customer);
            customerRepository.SaveChanges();
        }
    }
}
