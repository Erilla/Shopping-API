using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShoppingAPI.Business.Repositories;
using ShoppingAPI.Business.Services;
using ShoppingAPI.EntityFramework;

namespace ShoppingAPI.Business
{
    public static class ServicesConfiguration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Repositories
            services.AddTransient<IProductRepository, ProductRepository>();

            // Services
            services.AddTransient<IProductService, ProductService>();

            services.AddScoped<ShoppingDbContext>();

            // Mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ShoppingMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
