using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ProductProject.Setup.Extensions
{
    public static class MongoDBClientExtensions
    {
        public static IServiceCollection AddMongoDBClientConfiguration(
            this IServiceCollection services, IConfiguration configuration) => services.AddSingleton(_ =>
            {
                var settings = MongoClientSettings.FromUrl(
                    new MongoUrl(configuration.GetConnectionString("DatabaseServer")));

                var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                return new MongoClient(settings);
            });
    }
}
