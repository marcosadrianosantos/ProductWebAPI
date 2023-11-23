using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ProductProject.Data.Context;

namespace ProductProject.Setup.Extensions
{
    public static class MongoDBExtensions
    {
        public static IServiceCollection MongoDBContext(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddScoped(x => new MongoDBContext(
                    x.GetRequiredService<MongoClient>().GetDatabase(config.GetConnectionString("ProductApiDatabase"))
                    )
                );
        }
    }
}
