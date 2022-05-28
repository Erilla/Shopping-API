using ShoppingAPI.EntityFramework;
using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingDbContext _dbContext;
        private readonly ICustomerRepository _customerRepository;

        public ProductRepository(ShoppingDbContext dbContext, ICustomerRepository customerRepository)
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
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

        public decimal GetProductPriceByCustomerIdAndProductCode(int customerId, string productCode)
        {
            var customer = _customerRepository.FindCustomerById(customerId);
            return FindPriceByCustomerIdAndProductCode(customer.Id, productCode);
        }

        public decimal GetProductPriceByCustomerNameAndProductCode(string customerName, string productCode)
        {
            var customer = _customerRepository.FindCustomerByName(customerName);
            return FindPriceByCustomerIdAndProductCode(customer.Id, productCode);
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
                throw new InvalidOperationException($"Product with product code {productCode} not found.");
            }
        }

        private decimal FindPriceByCustomerIdAndProductCode(int customerId, string productCode)
        {
            var specificPrice = _dbContext.SpecificPrices.Where(sp => sp.Customer.Id.Equals(customerId) && sp.Product.ProductCode.Equals(productCode)).FirstOrDefault();
            if (specificPrice == null)
            {
                var product = FindProduct(productCode);
                return product.ProductPrice;
            }
            else
            {
                return specificPrice.Price;
            }
        }
    }
}
