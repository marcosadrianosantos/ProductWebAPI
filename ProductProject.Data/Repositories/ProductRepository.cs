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
        public async Task<List<Product>> GetAllAsync() => await _context.Products.AsQueryable().ToListAsync();
        public async Task<Product> GetByIdAsync(string id) => await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task UpdateAsync(string id, Product product) => await _context.Products.ReplaceOneAsync(x => x.Id == id, product);
        public async Task<DeleteResult> DeleteAsync(string id) => await _context.Products.DeleteOneAsync(x => x.Id == id);
    }
}
