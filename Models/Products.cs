using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Products
    {
        [Key] public int product_id { get; set; }
        public string product_name { get; set; }
        public decimal price { get; set; }
    }
}