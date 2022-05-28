namespace ShoppingAPI.Business.Services
{
    public interface ISpecificPriceService
    {
        void CreateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal price);

        void CreateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal price);

        void UpdateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal newPrice);

        void UpdateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal newPrice);

        void DeleteSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode);

        void DeleteSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode);
    }
}
