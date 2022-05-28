using ShoppingAPI.Business.Models;

namespace ShoppingAPI.Business.Repositories
{
    internal interface IProductRepository
    {
        Product GetProductByProductCode(string productCode);

        void UpdateProduct(Product product);

        void AddProduct(Product product);

        void DeleteProduct(Product product);
    }
}
