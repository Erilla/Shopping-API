using Microsoft.Extensions.DependencyInjection;
using ShoppingAPI.Business.Repositories;
using ShoppingAPI.Business.Services;

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
        }
    }
}
