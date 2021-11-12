using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NextSol.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        [MaxLength(50)]
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
