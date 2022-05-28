using ShoppingAPI.EntityFramework;
using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoppingDbContext _dbContext;

        public CustomerRepository(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCustomer(string customerName)
        {
            var customer = _dbContext.Customers.Where(cust => cust.Name.Equals(customerName)).FirstOrDefault();
            if (customer == null)
            {
                _dbContext.Customers.Add(new CustomerEntity
                {
                    Name = customerName
                });
                _dbContext.SaveChanges();
            } 
            else
            {
                throw new ArgumentException($"Customer {customerName} already exists."); // Not great if there's users with the same name...
            }
        }

        public CustomerEntity FindCustomerById(int customerId)
        {
            var customer = _dbContext.Customers.Where(cust => cust.Id.Equals(customerId)).FirstOrDefault();
            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new InvalidOperationException($"Customer with customer id {customerId} not found.");
            }
        }

        public CustomerEntity FindCustomerByName(string customerName)
        {
            var customer = _dbContext.Customers.Where(cust => cust.Name.Equals(customerName)).FirstOrDefault();
            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new InvalidOperationException($"Customer with customer name {customerName} not found.");
            }
        }
    }
}
