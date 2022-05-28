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
            services.AddTransient<ISpecificPriceRepository, SpecificPriceRepository>();

            // Services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISpecificPriceService, SpecificPriceService>();

            services.AddScoped<ShoppingDbContext>();
        }
    }
}
