using ShoppingAPI.EntityFramework;
using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business.Repositories
{
    public class SpecificPriceRepository : ISpecificPriceRepository
    {
        private readonly ShoppingDbContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public SpecificPriceRepository(ShoppingDbContext dbContext, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public void CreateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal price)
        {
            _customerRepository.FindCustomerById(customerId); // Checks if customer exists
            CreateSpecificPrice(customerId, productCode, price);
        }

        public void CreateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal price)
        {
            CustomerEntity customer;
            try
            {
                customer = _customerRepository.FindCustomerByName(customerName);
            } 
            catch(InvalidOperationException)
            {
                _customerRepository.CreateCustomer(customerName);
                customer = _customerRepository.FindCustomerByName(customerName);
            }
            CreateSpecificPrice(customer.Id, productCode, price);
        }

        public void DeleteSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode)
        {
            var specificPrice = GetSpecificPriceByCustomerIdAndProductCode(customerId, productCode);
            _dbContext.SpecificPrices.Remove(specificPrice);
            _dbContext.SaveChanges();
        }

        public void DeleteSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode)
        {
            var specificPrice = GetSpecificPriceByCustomerNameAndProductCode(customerName, productCode);
            _dbContext.SpecificPrices.Remove(specificPrice);
            _dbContext.SaveChanges();
        }

        public SpecificPriceEntity GetSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode)
        {
            var specificPrice = _dbContext.SpecificPrices.Where(sp => sp.Customer.Id.Equals(customerId) && sp.Product.ProductCode.Equals(productCode)).FirstOrDefault();

            if (specificPrice != null)
            {
                return specificPrice;
            }
            else
            {
                throw new InvalidOperationException($"No specific price found with customer id {customerId} and product code {productCode}.");
            }
        }

        public SpecificPriceEntity GetSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode)
        {
            var specificPrice = _dbContext.SpecificPrices.Where(sp => sp.Customer.Name.Equals(customerName) && sp.Product.ProductCode.Equals(productCode)).FirstOrDefault();

            if (specificPrice != null)
            {
                return specificPrice;
            }
            else
            {
                throw new InvalidOperationException($"No specific price found with customer name {customerName} and product code {productCode}.");
            }
        }

        public void UpdateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal newPrice)
        {
            var specificPrice = GetSpecificPriceByCustomerIdAndProductCode(customerId, productCode);
            specificPrice.Price = newPrice;
            _dbContext.SaveChanges();
        }

        public void UpdateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal newPrice)
        {
            var specificPrice = GetSpecificPriceByCustomerNameAndProductCode(customerName, productCode);
            specificPrice.Price = newPrice;
            _dbContext.SaveChanges();
        }

        private void CreateSpecificPrice(int customerId, string productCode, decimal price)
        {
            var specificPrice = _dbContext.SpecificPrices.Where(sp => sp.Customer.Id.Equals(customerId) && sp.Product.ProductCode.Equals(productCode)).FirstOrDefault();

            if (specificPrice == null)
            {
                var product = _productRepository.GetProductByProductCode(productCode);



                _dbContext.SpecificPrices.Add(new SpecificPriceEntity
                {
                    CustomerId = customerId,
                    ProductId = product.Id,
                    Price = price
                });
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Specific Price for customer {customerId} and product code {productCode} already exists.");
            }
        }
    }
}
