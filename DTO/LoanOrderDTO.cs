using System.Collections.Generic;

namespace Shop.DTO
{
    public class LoanOrderDTO
    {
        public int Customer_id { get; set; }
        public List<int> orders { get; set; }
    }
}