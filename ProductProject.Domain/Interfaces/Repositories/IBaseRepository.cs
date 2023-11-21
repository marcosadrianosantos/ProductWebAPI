namespace ProductProject.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<List<TEntity>> GetAll();
        Task UpdateAsync(string id, TEntity obj);
        Task DeleteAsync(string id);
    }
}
