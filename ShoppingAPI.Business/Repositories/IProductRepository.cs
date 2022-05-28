using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business.Repositories
{
    public interface IProductRepository
    {
        ProductEntity GetProductByProductCode(string productCode);

        void UpdateProductPriceByProductCode(string productCode, decimal newPrice);

        void AddProduct(ProductEntity product);

        void DeleteProduct(ProductEntity product);
    }
}
