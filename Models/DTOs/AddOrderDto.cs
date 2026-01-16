using StockSphere_DN.Models.Entities;

namespace StockSphere_DN.Models.DTOs
{
    public class AddOrderDto
    {
        public string StockSymbol { get; set; } = string.Empty;
        // Use the same enums defined in Order
        public Order.OrderType Type { get; set; } 
        public Order.OrderStatus Status { get; set; } 
        public int OrderQuantity { get; set; } 
        public int OrderPrice { get; set; } 
        // Foreign key reference to UserProfile
        public Guid UserId { get; set; }
    }
}
