using Core.Entities.Abstract;

namespace Core.Business.Abstract
{
    public interface IAsyncServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task DeleteAllAsync();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
    }
}
