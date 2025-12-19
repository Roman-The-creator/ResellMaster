using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyWinFormsApp.Data;
using MyWinFormsApp.Models;

namespace MyWinFormsApp.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService()
        {
            _context = new AppDbContext();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<ProductRow> GetProductRows()
        {
            var products = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Sales)
                .ToList();

            return products.Select(p =>
            {
                var sale = p.Sales
                    .OrderByDescending(s => s.SaleDate)
                    .FirstOrDefault();

                decimal? netSalePrice = null;

                if (sale != null)
                {
                    var platformFee = sale.SalePrice * sale.PlatformFeePercent / 100m;

                    netSalePrice =
                        sale.SalePrice
                        - sale.AdCost
                        - sale.ViewsCost
                        - platformFee;

                }

                return new ProductRow
                {
                    Id = p.Id,
                    Name = p.Name,
                    Size = p.Size,
                    Quantity = p.Quantity,
                    UnitPurchasePrice = p.UnitPurchasePrice,
                    PurchasePrice = p.PurchasePrice,

                    // 🔥 В ТАБЛИЦЕ ПОКАЗЫВАЕМ ЧИСТУЮ ЦЕНУ
                    SalePrice = netSalePrice,

                    PurchaseDate = p.PurchaseDate,
                    Status = p.Status.ToString(),
                    Brand = p.Brand?.Name ?? "",
                    Category = p.Category?.Name ?? ""
                };
            }).ToList();
        }



        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new InvalidOperationException("Название товара обязательно.");
            if (product.Quantity <= 0)
                throw new InvalidOperationException("Количество должно быть больше 0.");
            if (product.UnitPurchasePrice <= 0)
                throw new InvalidOperationException("Цена за штуку должна быть больше 0.");

            product.PurchasePrice = product.Quantity * product.UnitPurchasePrice;
            product.Status = ItemStatus.InStock;

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void SellProduct(int productId, decimal salePrice, int platformId, string customer,
                        decimal adCost, decimal viewsCost, decimal platformFeePercent)

        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new InvalidOperationException("Товар не найден.");

            if (product.Status == ItemStatus.Sold)
                throw new InvalidOperationException("Товар уже продан.");

            var platformFee = salePrice * platformFeePercent / 100m;
            var totalExpenses = product.PurchasePrice + adCost + viewsCost + platformFee;
            var profit = salePrice - totalExpenses;

            product.Status = ItemStatus.Sold;

            var sale = new Sale
            {
                ProductId = productId,
                SalePrice = salePrice,
                SaleDate = DateTime.Now,
                PlatformId = platformId,
                CustomerInfo = customer ?? "",

                AdCost = adCost,
                ViewsCost = viewsCost,
                PlatformFeePercent = platformFeePercent,

            };

            _context.Sales.Add(sale);
            _context.SaveChanges();



            _context.Sales.Add(sale);
            _context.SaveChanges();
        }



        public void DeleteProduct(int productId, bool allowDeleteSold = false)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return;

            if (!allowDeleteSold && product.Status == ItemStatus.Sold)
                throw new InvalidOperationException("Нельзя удалить проданный товар.");

            var sales = _context.Sales.Where(s => s.ProductId == productId).ToList();
            if (sales.Count > 0) _context.Sales.RemoveRange(sales);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public decimal GetTotalProfit()
        {
            var sales = _context.Sales
                .Include(s => s.Product)
                .Where(s => s.Product != null)
                .ToList();

            return sales.Sum(s =>
            {
                var platformFee = s.SalePrice * s.PlatformFeePercent / 100m;

                var netSale =
                    s.SalePrice
                    - s.AdCost
                    - s.ViewsCost
                    - platformFee;

                return netSale - s.Product!.PurchasePrice;
            });
        }


        public decimal GetInventoryValue()
        {
            var values = _context.Products
                .AsNoTracking()
                .Where(p => p.Status == ItemStatus.InStock)
                .Select(p => p.PurchasePrice)
                .ToList();

            return values.Sum();
        }

        public List<Brand> GetBrands() => _context.Brands.OrderBy(b => b.Name).ToList();
        public List<Category> GetCategories() => _context.Categories.OrderBy(c => c.Name).ToList();
        public List<Platform> GetPlatforms() => _context.Platforms.OrderBy(p => p.Name).ToList();

        public void ExportProductsToCsv(string path)
        {
            var rows = GetProductRows();

            var enc = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
            using var writer = new StreamWriter(path, false, enc);

            writer.WriteLine("Id;Name;Size;Quantity;UnitPurchasePrice;PurchasePrice;SalePrice;Brand;Category;Status;PurchaseDate");

            foreach (var r in rows)
            {
                writer.WriteLine(
                    $"{r.Id};{Esc(r.Name)};{Esc(r.Size)};{r.Quantity};{r.UnitPurchasePrice};{r.PurchasePrice};{(r.SalePrice.HasValue ? r.SalePrice.Value.ToString() : "")};{Esc(r.Brand)};{Esc(r.Category)};{Esc(r.Status)};{r.PurchaseDate:yyyy-MM-dd HH:mm}"
                );
            }
        }

        private static string Esc(string? v)
        {
            v ??= "";
            v = v.Replace("\"", "\"\"");
            if (v.Contains(';') || v.Contains('\n') || v.Contains('\r'))
                return $"\"{v}\"";
            return v;
        }

        public void SeedData()
        {
            bool changed = false;

            if (!_context.Categories.Any())
            {
                _context.Categories.AddRange(
                    new Category { Name = "Кроссовки" },
                    new Category { Name = "Одежда" }
                );
                changed = true;
            }

            if (!_context.Platforms.Any())
            {
                _context.Platforms.AddRange(
                    new Platform { Name = "Avito" },
                    new Platform { Name = "Telegram" }
                );
                changed = true;
            }

            if (!_context.Brands.Any())
            {
                _context.Brands.AddRange(
                    new Brand { Name = "Nike" },
                    new Brand { Name = "Jordan" }
                );
                changed = true;
            }

            if (changed) _context.SaveChanges();
        }
    }
}
