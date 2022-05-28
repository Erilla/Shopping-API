using ShoppingAPI.Business.Models;

namespace ShoppingAPI.Business.Services
{
    public interface IProductService
    {
        Product GetProductByProductCode(string productCode);

        decimal GetProductPriceByCustomerIdAndProductCode(int customerId, string productCode);

        decimal GetProductPriceByCustomerNameAndProductCode(string customerName, string productCode);

        void UpdateProductPriceByProductCode(string productCode, decimal newPrice);

        void AddProduct(Product product);
    }
}
