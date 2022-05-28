using AutoMapper;
using ShoppingAPI.Business.Models;
using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business
{
    public class ShoppingMappingProfile : Profile
    {
        public ShoppingMappingProfile()
        {
            CreateMap<ProductEntity, Product>();
            CreateMap<Product, ProductEntity>();
            CreateMap<CustomerEntity, Customer>();
            CreateMap<Customer, CustomerEntity>();

        }
    }
}
