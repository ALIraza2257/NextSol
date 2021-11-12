using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextSol.Models;

namespace NextSol.VM
{
    public class OrderVM
    {
        public OrderMaster OrderMaster { get; set; }
        public IEnumerable<Customer> Custlist { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderRaw
    {
        
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string ShipingAddress { get; set; }
        public decimal NeTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Gtotal { get; set; }
        public string Name { get; set; }
    }
}
