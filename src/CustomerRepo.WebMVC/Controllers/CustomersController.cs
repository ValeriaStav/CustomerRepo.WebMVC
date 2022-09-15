using CustomerManagement.Business;
using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace CustomerRepo.WebMVC.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerService _customerService;

        public CustomersController()
        {
            _customerService = new CustomerService();
        }

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customers
        public ActionResult Index(int entity)
        {
            var customer = _customerService.GetAll();
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            var defaultValues = new Customer();
            defaultValues.Addresses = new List<Address>()
            {
                new Address()
            };

            return View(defaultValues);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(customer);
                return View(customer);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Massage = "Value isn't valid";
                return View("Error");
            }

            return View("Index");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                _customerService.Update(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                // TODO: Add delete logic here

                var _noteRepository = new NoteRepository();
                var _addressRepository = new AddressRepository();
                var _customerRepository = new CustomerRepository();

                _noteRepository.DeleteAll();
                _addressRepository.DeleteAll();
                _customerRepository.DeleteAll();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        public object Index()
        {
            throw new NotImplementedException();
        }
    }
}
