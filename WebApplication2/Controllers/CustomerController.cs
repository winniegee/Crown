using Domain.Entities;
using Service;
using Service_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController:Controller
    {
        private readonly ICustomerService customerService;
        public CustomerController()
        {
            this.customerService = new CustomerService();
        }

       
        [Route("index")]
        public ActionResult Index()
        {
            List<CustomerViewModel> model = new List<CustomerViewModel>();
            customerService.GetCustomers().ToList().ForEach(s =>
            {
                Customer customer = customerService.GetCustomer(s.Id);
                CustomerViewModel customerRep = new CustomerViewModel
                {
                    Id = s.Id,
                    UserName = $"{customer.FirstName} {customer.LastName}",
                    Address = customer.Address,
                    Phone=customer.Phone
                };
                model.Add(customerRep);
            });
            return View(model);
        }
        
        
        public ActionResult AddCustomer()
        {
            CustomerViewModel model = new CustomerViewModel();
            return View();
            //return PartialView(@"c:\users\winnie\source\repos\Crown\WebApplication2\Views\Customer\AddCustomer.cshtml", model);
        }

        [HttpPost]
      
        public ActionResult AddCustomer(CustomerViewModel model)
        {
            Customer customer = new Customer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateAdded = DateTime.Now,
                Address = model.Address,
                Phone = model.Phone,
            };
            customerService.AddCustomer(customer);
            if (customer.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = customerService.GetCustomer(id);
            string name = $"{customer.FirstName} {customer.LastName}";
            return PartialView("_DeleteCustomer", name);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection form)
        {
            customerService.DeleteCustomer(id);
            return RedirectToAction("index");
        }
    }
    
}