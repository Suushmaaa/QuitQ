using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QuitQ_Ecomm.DTOS
{
    public class OrderDto
    {
        public required List<int> ProductIds { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
