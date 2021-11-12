using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NextSol.Models
{
    public class OrderMaster
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        [MaxLength(200)]
        public string ShipingAddress { get; set; }
        public decimal NeTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Gtotal { get; set; }
    }
}
