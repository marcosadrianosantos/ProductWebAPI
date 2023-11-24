using MongoDB.Bson;
using MongoDB.Driver;
using ProductProject.Data.Context;
using ProductProject.Domain.Interfaces.Repositories;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDBContext _context;

        public ProductRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product) => await _context.Products.InsertOneAsync(product);
        public async Task<Product> GetByIdAsync(string id) 
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$lookup",
                    new BsonDocument
                    {
                        { "from", "Categories" },
                        { "localField", "CategoryId" },
                        { "foreignField", "_id" },
                        { "as", "Category" }
                    }),
                new BsonDocument("$unwind", "$Category")
            };
            return await _context.Products.Aggregate<Product>(pipeline).FirstOrDefaultAsync();
        } 
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$lookup",
                    new BsonDocument
                    {
                        { "from", "Categories" },
                        { "localField", "CategoryId" },
                        { "foreignField", "_id" },
                        { "as", "Category" }
                    }),
                new BsonDocument("$unwind", "$Category")
            };

            return await _context.Products.Aggregate<Product>(pipeline).ToListAsync();
        }

        public async Task UpdateAsync(string id, Product product) => await _context.Products.ReplaceOneAsync(x => x.Id == id, product);
        public async Task<DeleteResult> DeleteAsync(string id) => await _context.Products.DeleteOneAsync(x => x.Id == id);
        public async Task<Product> GetByCategoryId(string id) => await _context.Products.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
    }
}
