using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormsApp.Models
{
    public class ProductRow
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Size { get; set; } = "";
        public int Quantity { get; set; }

        public decimal UnitPurchasePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }

        public string Brand { get; set; } = "";
        public string Category { get; set; } = "";

        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; } = "";
        public decimal? GrossSalePrice { get; set; } // как ввел (15000)
        public decimal? NetSalePrice { get; set; }   // чистая после расходов

    }
}

