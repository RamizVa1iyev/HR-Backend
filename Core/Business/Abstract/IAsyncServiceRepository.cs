using Core.Entities.Abstract;
using Core.Features.Results.Abstract;

namespace Core.Business.Abstract
{
    public interface IAsyncServiceRepository<T> where T : class, IEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task DeleteAllAsync();
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}
