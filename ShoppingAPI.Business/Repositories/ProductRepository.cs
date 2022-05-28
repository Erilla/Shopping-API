using ShoppingAPI.EntityFramework;
using ShoppingAPI.EntityFramework.Entities;
using System.Data.Entity.Core;

namespace ShoppingAPI.Business.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ShoppingDbContext _dbContext;

        public ProductRepository(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(ProductEntity product)
        {
            if (_dbContext.Products.SingleOrDefault(p => p.ProductCode.Equals(product.ProductCode)) == null)
            {
                _dbContext.Add(product);
                _dbContext.SaveChanges();
            } 
            else
            {
                throw new ArgumentException($"Product Code {product.ProductCode} already exists.");
            }
        }

        public void DeleteProduct(ProductEntity product)
        {
            throw new NotImplementedException();
        }

        public ProductEntity GetProductByProductCode(string productCode) => FindProduct(productCode);

        public void UpdateProductPriceByProductCode(string productCode, decimal newPrice)
        {
            var product = FindProduct(productCode);
            product.ProductPrice = newPrice;
            _dbContext.SaveChanges();
        }

        private ProductEntity FindProduct(string productCode)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductCode.Equals(productCode.ToUpper()));
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new ObjectNotFoundException($"Product with product code {productCode} not found.");
            }
        }
    }
}
