using MongoDB.Driver;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Data.Context
{
    public class MongoDBContext
    {
        public MongoDBContext(IMongoDatabase database) => Database = database;
        public IMongoDatabase Database { get; }
        public IMongoCollection<Product> Products => Database.GetCollection<Product>("Products");
        public IMongoCollection<Category> Categories => Database.GetCollection<Category>("Categories");
    }
}
