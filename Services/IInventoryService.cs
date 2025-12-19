using System.Collections.Generic;
using MyWinFormsApp.Models;

namespace MyWinFormsApp.Services
{
    public interface IInventoryService
    {
        
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        List<ProductRow> GetProductRows();
        List<Brand> GetBrands();
        List<Category> GetCategories();
        List<Platform> GetPlatforms();

        // Операции с товарами
        void AddProduct(Product product);
        void SellProduct(int productId, decimal salePrice, int platformId, string customer,
                         decimal adCost, decimal viewsCost, decimal platformFeePercent);
        void DeleteProduct(int productId, bool allowDeleteSold = false);

        // Аналитика и экспорт
        decimal GetTotalProfit();
        decimal GetInventoryValue();
        void ExportProductsToCsv(string path);

        // Служебные
        void SeedData();
    }
}

