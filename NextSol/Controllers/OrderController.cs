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
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Orders= new Repo<OrderRaw>().GetAllData("SELECT OrderMasters.*, Customers.Name FROM OrderMasters INNER JOIN Customers ON OrderMasters.CustomerId = Customers.Id").ToList();
            return View(Orders);
        }

        public ActionResult Order(OrderMaster OrderMaster)
        {
            OrderMaster.OrderDate = DateTime.Now;
            OrderMaster.RequiredDate = DateTime.Now;
            OrderMaster.OrderId = new Repo<string>().GetMaxId("select ISNULL(Max(OrderMasters.OrderId),0)+1 from OrderMasters");
            var VM = new OrderVM
            {
                OrderMaster= OrderMaster,
                Custlist = _context.Customers.ToList(),
            };
            return View(VM);
        }
        [HttpPost]
        public ActionResult Save(OrderMaster OrderMaster,  string[] ItemName, decimal[] CP, decimal[] qty, decimal[] nettotal)
        {
            string varDirection = "";
            
            if (OrderMaster.Id == 0)
            {
                if(ItemName.Count() > 0)
                {
                    for (int i = 0; i < ItemName.Count(); i++)
                    {
                        _context.Database.ExecuteSqlRaw("INSERT INTO OrderDetails (OrderId, ItemName, Qty, Price, Total)  VALUES ('" + OrderMaster.OrderId + "','" + ItemName[i] + "','" + qty[i] + "','" + CP[i] + "','" + nettotal[i] + "')");
                    }
                }
                _context.Database.ExecuteSqlRaw("INSERT INTO OrderMasters (CustomerId, OrderId, OrderDate, RequiredDate, NeTotal,Discount,Gtotal,ShipingAddress)  " +
                    "VALUES ('" + OrderMaster.CustomerId + "','" + OrderMaster.OrderId + "','" + OrderMaster.OrderDate + "','" + OrderMaster.RequiredDate + "','" + OrderMaster.NeTotal + "','" + OrderMaster.Discount + "','" + OrderMaster.Gtotal + "','" + OrderMaster.ShipingAddress + "')");
               
                varDirection = "Order";

            }
            else
            {
                _context.Database.ExecuteSqlRaw("DELETE FROM OrderMasters WHERE  (OrderId = '" + OrderMaster.OrderId + "')  ");
                _context.Database.ExecuteSqlRaw("DELETE FROM OrderDetails  WHERE  (OrderId = '" + OrderMaster.OrderId + "')  ");
                if (ItemName.Count() > 0)
                {
                    for (int i = 0; i < ItemName.Count(); i++)
                    {
                        _context.Database.ExecuteSqlRaw("INSERT INTO OrderDetails (OrderId, ItemName, Qty, Price, Total)  VALUES ('" + OrderMaster.OrderId + "','" + ItemName[i] + "','" + qty[i] + "','" + CP[i] + "','" + nettotal[i] + "')");
                    }
                }
                _context.Database.ExecuteSqlRaw("INSERT INTO OrderMasters (CustomerId, OrderId, OrderDate, RequiredDate, NeTotal,Discount,Gtotal,ShipingAddress)  " +
                   "VALUES ('" + OrderMaster.CustomerId + "','" + OrderMaster.OrderId + "','" + OrderMaster.OrderDate + "','" + OrderMaster.RequiredDate + "','" + OrderMaster.NeTotal + "','" + OrderMaster.Discount + "','" + OrderMaster.Gtotal + "','" + OrderMaster.ShipingAddress + "')");
                varDirection = "Index";
            }
            return RedirectToAction(varDirection, "Order");
        }
        [HttpGet]
        public ActionResult Edit(int? OrderId)
        {
            var VM = new OrderVM
            {
                OrderDetails = _context.OrderDetails.FromSqlRaw("SELECT  * FROM   OrderDetails  WHERE   (OrderId = '" + OrderId + "') ").ToList(),
                OrderMaster = _context.OrderMasters.FromSqlRaw("SELECT * FROM   OrderMasters WHERE  (OrderId = '" + OrderId + "') ").FirstOrDefault(),
                Custlist = _context.Customers.ToList(),
            };
            return View("Order", VM);
        }
    }
}
