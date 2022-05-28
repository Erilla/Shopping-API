using ShoppingAPI.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Business.Repositories
{
    public class SpecificPriceRepository : ISpecificPriceRepository
    {
        public void CreateSpecificPriceByCustomerIdAndProductCode(SpecificPriceEntity specificPrice)
        {
            throw new NotImplementedException();
        }

        public void CreateSpecificPriceByCustomerNameAndProductCode(SpecificPriceEntity specificPrice)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
