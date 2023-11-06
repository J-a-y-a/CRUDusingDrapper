using CRUDusingDrapper.Models;
using CRUDusingDrapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingDrapper.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository customerRepo = new CustomerRepository();
        // GET: Customer
        public ActionResult GetAllCustomerDetails()
        {
           
            return View(customerRepo.GetAllCustomers());
        }
        // GET: Employee/AddEmployee      
        public ActionResult AddCustomer()
        {
            return View();
        }

        // POST: Employee/AddEmployee      
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepo.AddCustomer(customer);
                    ViewBag.Message = "Records added successfully.";
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public ActionResult Edit(int id)
        {
            return View(customerRepo.GetAllCustomers().Find(Emp => Emp.CustomerID== id));
        }

        // POST:Update the details into database      
        [HttpPost]
        public ActionResult Edit(int id, Customer obj)
        {
            try
            {
             
                customerRepo.UpdateCustomer(obj);
                return RedirectToAction("GetAllCustomerDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Employee details by id      
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                if (customerRepo.DeleteCustomer(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllCustomerDetails");
            }
            catch
            {
                return RedirectToAction("GetAllCustomerDetails");
            }
        }
    }
}
