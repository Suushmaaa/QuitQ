using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuitQ.API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Shipped, Delivered
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
