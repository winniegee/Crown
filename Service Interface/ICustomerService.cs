using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Interface
{
    public interface ICustomerService
    {

        IEnumerable<Customer> GetCustomers();
        void AddCustomer(Customer customer);
        Customer GetCustomer(int id);
        void DeleteCustomer(int id);
        void Update(Customer customer);
    }
}
