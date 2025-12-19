using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Models
{
    public enum ItemStatus { InStock, Sold, Reserved }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;
        public decimal UnitPurchasePrice { get; set; }

        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public ItemStatus Status { get; set; } = ItemStatus.InStock;

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        // ✅ чтобы работало p.Sales
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
