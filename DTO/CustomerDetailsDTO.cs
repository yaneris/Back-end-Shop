using System.Collections.Generic;

namespace Shop.DTO
{
    public class CustomerDetailsDTO : CustomerDTO
    {
        public List<OrderDTO> Orders { get; set; }
    }
}