using Microsoft.EntityFrameworkCore;
using MyWinFormsApp.Models;
using MyWinFormsApp.Models;
using System.IO;

namespace MyWinFormsApp.Data
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Получаем путь к папке, где запущен .exe
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(baseDir, "resellmaster.db");

            // Указываем полный путь к базе
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
