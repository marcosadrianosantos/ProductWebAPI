using ProductProject.Domain.Models.Response;

namespace ProductProject.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByCategoryId(string id);
    }
}
