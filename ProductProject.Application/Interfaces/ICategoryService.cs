using ProductProject.Domain.Models.Request;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(CategoryRequest categoryRequest);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task<Category> UpdateAsync(string id, CategoryRequest categoryRequest);
        Task<bool> DeleteAsync(string id);
    }
}
