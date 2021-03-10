using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Customer
    {
        [Key] 
        public int id { get; set; }

        public string name { get; set; }
    }
}