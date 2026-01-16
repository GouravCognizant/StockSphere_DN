using System.ComponentModel.DataAnnotations.Schema;

namespace StockSphere_DN.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public required string  StockSymbol { get; set; }

        public OrderType Type { get; set; }

        public OrderStatus Status { get; set; }

        public int OrderQuantity { get; set; }

        public required int OrderPrice { get; set; }
        [ForeignKey("UserProfile")] 
        public Guid UserId { get; set; }
        // Navigation property
        public UserProfile? UserProfile { get; set; }


        public enum OrderType { Buy, Sell }
        public enum OrderStatus { Pending, Completed, Cancelled }
    }
}
