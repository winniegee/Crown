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
    public class EditController : Controller
    {
        private readonly ICustomerService customerService;
        public EditController()
        {
            this.customerService = new CustomerService();
        }
        // GET: Edit
        public ActionResult EditCustomer(int? id)
        {
            CustomerViewModel model=new CustomerViewModel();
            if (id.HasValue && id != 0)
            {
                Customer customer = customerService.GetCustomer(id.Value);
                model.FirstName = customer.FirstName;
                model.LastName = customer.LastName;
                model.Address = customer.Address;
                model.Phone = customer.Phone;
            }
            return View();
            //return PartialView("_EditUser", model);
        }
        [HttpPost]
        public ActionResult EditCustomer(CustomerViewModel model)
        {
            Customer customer = customerService.GetCustomer(model.Id);
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Address = model.Address;
            customer.Phone = model.Phone;
            customerService.Update(customer);
            if (customer.Id > 0)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}