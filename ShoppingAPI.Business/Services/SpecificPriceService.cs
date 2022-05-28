using ShoppingAPI.Business.Repositories;

namespace ShoppingAPI.Business.Services
{
    public class SpecificPriceService : ISpecificPriceService
    {
        private readonly ISpecificPriceRepository _specificPriceRepository;

        public SpecificPriceService(ISpecificPriceRepository specificPriceRepository)
        {
            _specificPriceRepository = specificPriceRepository;
        }

        public void CreateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal price)
        {
            _specificPriceRepository.CreateSpecificPriceByCustomerIdAndProductCode(customerId, productCode, price);
        }

        public void CreateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal price)
        {
            _specificPriceRepository.CreateSpecificPriceByCustomerNameAndProductCode(customerName, productCode, price);
        }

        public void DeleteSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode)
        {
            _specificPriceRepository.DeleteSpecificPriceByCustomerIdAndProductCode(customerId, productCode);
        }

        public void DeleteSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode)
        {
            _specificPriceRepository.DeleteSpecificPriceByCustomerNameAndProductCode(customerName, productCode);
        }

        public void UpdateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal newPrice)
        {
            _specificPriceRepository.UpdateSpecificPriceByCustomerIdAndProductCode(customerId, productCode, newPrice);
        }

        public void UpdateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal newPrice)
        {
            _specificPriceRepository.UpdateSpecificPriceByCustomerNameAndProductCode(customerName, productCode, newPrice);
        }
    }
}
