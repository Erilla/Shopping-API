using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppingAPI.Business.Seeddata.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.ProductCode).UseCollation("NOCASE");

            modelBuilder.Entity<CustomerEntity>()
                .Property(e => e.Name).UseCollation("NOCASE");

            using StreamReader r = new("../ShoppingAPI.Business/Seeddata/customer-data.json");
            string json = r.ReadToEnd();
            var seedData = JsonConvert.DeserializeObject<RootSeedModel>(json);
            if (seedData != null)
            {
                int productId = 1;
                var products = new List<ProductEntity>();

                seedData.Products.ForEach(product =>
                {
                    if (decimal.TryParse(product.Price, out var price))
                    {
                        var productEntity = new ProductEntity
                        {
                            Id = productId,
                            ProductCode = product.ProductCode,
                            ProductPrice = price
                        };

                        modelBuilder.Entity<ProductEntity>().HasData(productEntity);
                        products.Add(productEntity);
                        productId++;
                    }
                });

                int customerId = 1;
                int specificPriceId = 1;

                seedData.SpecificPrices.ForEach(specificPrice =>
                {
                    modelBuilder.Entity<CustomerEntity>().HasData(new CustomerEntity
                    {
                        Id = customerId,
                        Name = specificPrice.Customer
                    });

                    specificPrice.Products.ForEach(specificProduct =>
                    {
                        var product = products.FirstOrDefault(product => product.ProductCode.Equals(specificProduct.ProductCode));

                        if (product != null)
                        {
                            if (!decimal.TryParse(specificProduct.Price, out var specificPrice))
                            {
                                specificPrice = product.ProductPrice;
                            }

                            modelBuilder.Entity<SpecificPriceEntity>().HasData(new SpecificPriceEntity
                            {
                                Id = specificPriceId,
                                CustomerId = customerId,
                                ProductId = product.Id,
                                Price = specificPrice
                            });

                            specificPriceId++;
                        }
                    });

                    customerId++;
                });
            }
        }
    }    
}
