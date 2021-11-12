using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NextSol.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string ContactName { get; set; }
        [MaxLength(50)]
        public string ContactTitle { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Region { get; set; }
        [MaxLength(50)]
        public string PostalCode { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Fax { get; set; }
        
    }
}
