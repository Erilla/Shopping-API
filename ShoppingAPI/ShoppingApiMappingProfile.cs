using AutoMapper;
using ShoppingAPI.Business.Models;
using ShoppingAPI.Models;
using ShoppingAPI.EntityFramework.Entities;

namespace ShoppingAPI.Business
{
    public class ShoppingApiMappingProfile : Profile
    {
        public ShoppingApiMappingProfile()
        {
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
