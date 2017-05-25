using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using System.Data.Entity;
using VideoStore.ViewModel;

namespace VideoStore.Controllers
{
    public class CustomerController : Controller, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new CustomerFormViewModel()
            {
                Customer = new Customer()
            };

            model.MembershipTypes = _dbContext.MembershipTypes.ToList();

            return View("CustomerForm", model);
        }

        public ActionResult Edit(int customerId)
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel();
            viewModel.Customer = customer;
            viewModel.MembershipTypes = _dbContext.MembershipTypes.ToList();

            return View("CustomerForm", viewModel);
        }

        public ActionResult Delete(int customerId)
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == customerId);
            if (customer == null)
            {
                return HttpNotFound();
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //New
            if (customer.Id == 0)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var customerFromDb = _dbContext.Customers.SingleOrDefault(x => x.Id == customer.Id);

                customerFromDb.Name = customer.Name;
                customerFromDb.MembershipTypeId = customer.MembershipTypeId;
                customerFromDb.DateOfBirth = customer.DateOfBirth;
                customerFromDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }


            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var dbContext = new ApplicationDbContext();
            return dbContext.Customers.Include(x => x.MembershipType).ToList();

        }
    }
}