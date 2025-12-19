using System;

namespace MyWinFormsApp.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public decimal SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerInfo { get; set; } = string.Empty;

        public decimal Profit { get; set; }

        public int PlatformId { get; set; }
        public virtual Platform Platform { get; set; } = null!;

        // ✅ расходы/комиссия
        public decimal AdCost { get; set; } = 0m;               // реклама, ₽
        public decimal ViewsCost { get; set; } = 0m;            // просмотры, ₽
        public decimal PlatformFeePercent { get; set; } = 0m;   // комиссия, %
    }
}
