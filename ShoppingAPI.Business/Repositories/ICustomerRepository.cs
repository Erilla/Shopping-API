using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business.Repositories
{
    public interface ICustomerRepository
    {
        public CustomerEntity FindCustomerById(int customerId);

        public CustomerEntity FindCustomerByName(string customerName);

        public void CreateCustomer(string customerName);
    }
}
