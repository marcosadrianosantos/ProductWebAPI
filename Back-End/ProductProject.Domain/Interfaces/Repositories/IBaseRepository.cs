using MongoDB.Driver;

namespace ProductProject.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(string id, TEntity obj);
        Task<DeleteResult> DeleteAsync(string id);
    }
}
