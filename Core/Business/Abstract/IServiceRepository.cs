using Core.Entities.Abstract;

namespace Core.Business.Abstract
{
    public interface IServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        void DeleteAll();
        List<TEntity> GetAll();
        TEntity Get(int id);
    }
}
