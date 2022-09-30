using Core.Entities.Abstract;
using Core.Features.Results.Abstract;

namespace Core.Business.Abstract
{
    public interface IServiceRepository<T> where T : class, IEntity, new()
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        void DeleteAll();
        List<T> GetAll();
        T Get(int id);
    }
}
