using ProductProject.Domain.Models.Request;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(ProductRequest productRequest);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<Product> UpdateAsync(string id, ProductRequest productRequest);
        Task<bool> DeleteAsync(string id);
    }
}
