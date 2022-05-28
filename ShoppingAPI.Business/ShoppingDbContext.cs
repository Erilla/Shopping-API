using Microsoft.EntityFrameworkCore;
using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.EntityFramework
{
    public class ShoppingDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<SpecificPriceEntity> SpecificPrices { get; set; }

        public string DbPath { get; }

        public ShoppingDbContext()
        {
            var folder = Environment.CurrentDirectory;
            DbPath = Path.Join(folder, "shopping.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
