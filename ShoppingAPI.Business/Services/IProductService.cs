using ShoppingAPI.Business.Models;

namespace ShoppingAPI.Business.Services
{
    public interface IProductService
    {
        Product GetProductByProductCode(string productCode);

        void UpdateProductPriceByProductCode(string productCode, decimal newPrice);

        void AddProduct(Product product);

        void DeleteProduct(Product product);
    }
}
