using ShoppingAPI.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Business.Repositories
{
    public interface ISpecificPriceRepository
    {
        void CreateSpecificPriceByCustomerIdAndProductCode(SpecificPriceEntity specificPrice);

        void CreateSpecificPriceByCustomerNameAndProductCode(SpecificPriceEntity specificPrice);

        void UpdateSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode, decimal newPrice);

        void UpdateSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode, decimal newPrice);

        void DeleteSpecificPriceByCustomerIdAndProductCode(int customerId, string productCode);

        void DeleteSpecificPriceByCustomerNameAndProductCode(string customerName, string productCode);
    }
}
