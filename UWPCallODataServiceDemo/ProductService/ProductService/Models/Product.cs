
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductService.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string SupplierId { get; set; }
    }
}