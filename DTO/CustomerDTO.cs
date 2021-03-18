using System.ComponentModel.DataAnnotations;

namespace Shop.DTO
{
    public class CustomerDTO
    {
        public int Customer_id { get; set; }

        public string Name { get; set; }
        
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}