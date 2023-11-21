using MongoDB.Driver;
using ProductProject.Data.Context;
using ProductProject.Domain.Interfaces.Repositories;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MongoDBContext _context;

        public CategoryRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task Add(Category category) => await _context.Categories.InsertOneAsync(category);
        public async Task<List<Category>> GetAll() => await _context.Categories.AsQueryable().ToListAsync();
        public async Task<Category> GetById(string id) => await _context.Categories.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task UpdateAsync(string id, Category category) => await _context.Categories.ReplaceOneAsync(x => x.Id == id, category);
        public async Task DeleteAsync(string id) => await _context.Categories.DeleteOneAsync(x => x.Id == id);
    }
}
