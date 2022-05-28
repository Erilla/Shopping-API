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
            CreateMap<Product, ProductEntity>()
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.ProductCode.ToUpper()));
            CreateMap<CustomerEntity, Customer>();
            CreateMap<Customer, CustomerEntity>();
        }
    }
}
