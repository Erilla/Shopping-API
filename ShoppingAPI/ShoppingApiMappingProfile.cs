using AutoMapper;
using ShoppingAPI.Business.Models;
using ShoppingAPI.Models;

namespace ShoppingAPI.Business
{
    public class ShoppingApiMappingProfile : Profile
    {
        public ShoppingApiMappingProfile()
        {
            CreateMap<Product, GetProductPriceResponse>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(source => source.ProductPrice));

            CreateMap<decimal, GetProductPriceResponse>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(source => source));

            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
