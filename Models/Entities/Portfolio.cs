using System.ComponentModel.DataAnnotations.Schema;

namespace StockSphere_DN.Models.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }

        public required string StockSymbolName { get; set; }    
    
        public required int Quantity { get; set; }

        public required double AveragePrice { get; set; }

        public required int HoldingCount { get; set; }
        public required double InvestedAmount { get; set; }

        [ForeignKey("UserProfile")]
        public Guid UserId { get; set; }
    }
}
