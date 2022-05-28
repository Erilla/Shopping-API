using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business.Repositories
{
    public interface ISpecificPriceRepository
    {
        SpecificPriceEntity GetSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode);

        SpecificPriceEntity GetSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode);

        void CreateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal price);

        void CreateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal price);

        void UpdateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal newPrice);

        void UpdateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal newPrice);

        void DeleteSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode);

        void DeleteSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode);
    }
}
