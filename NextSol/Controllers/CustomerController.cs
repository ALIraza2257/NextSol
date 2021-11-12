using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextSol.Data;
using NextSol.Data.Repository;
using NextSol.Models;
using NextSol.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSol.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Customer = _context.Customers.ToList();
            return View(Customer);
        }
        [HttpGet]
        public IActionResult Customer(int? Id)
        {
            Customer model = new Customer();
            if (Id > 0)
            {
                model = _context.Customers.Where(c => c.Id == Id).FirstOrDefault();

            }
            else
            {
                model = new Customer();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Save(Customer Customer)
        {
            string vardirection = "";
            if (Customer.Id == 0)
            {
                _context.Customers.Add(Customer);
                _context.SaveChanges();
               
                vardirection = "Customer";

            }
            else
            {
                var Customerdb = _context.Customers.Single(c => c.Id == Customer.Id);
                Customerdb.CompanyName = Customer.CompanyName;
                Customerdb.ContactName = Customer.ContactName;
                Customerdb.ContactTitle = Customer.ContactTitle;
                Customerdb.Phone = Customer.Phone;
                Customerdb.Fax = Customer.Fax;
                Customerdb.PostalCode = Customer.PostalCode;
                Customerdb.Address = Customer.Address;
                Customerdb.Region = Customer.Region;
                Customerdb.City = Customer.City;
                Customerdb.Country = Customer.Country;
                _context.SaveChanges();
                vardirection = "Index";
            }
            return RedirectToAction(vardirection, "Customer");
        }

        public IActionResult OrderDetail(int? Id)
        {
            ViewBag.Orders = new Repo<OrderRaw>().GetAllData("SELECT OrderMasters.*, Customers.Name FROM OrderMasters INNER JOIN Customers ON OrderMasters.CustomerId = Customers.Id  WHERE  (OrderMasters.CustomerId = '" + Id + "')").ToList();
            var orderDetail = _context.OrderDetails.ToList();
            
            return View("OrderDetail", orderDetail);
        }
    }
}
