using ProductProject.Domain.Models.Response;

namespace ProductProject.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetById(string categoryId);
    }
}
