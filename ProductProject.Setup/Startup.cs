using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductProject.Application.Interfaces;
using ProductProject.Application.Services;
using ProductProject.Data.Repositories;
using ProductProject.Domain.Interfaces.Repositories;
using ProductProject.Setup.Extensions;

namespace ProductProject.Setup
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureApp(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureRepositories(services);

            services.AddMongoDBClientConfiguration(Configuration)
                    .MongoDBContext(Configuration);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

    }
}
