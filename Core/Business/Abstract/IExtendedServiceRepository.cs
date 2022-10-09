using Core.Entities.Abstract;

namespace Core.Business.Abstract
{
    public interface IExtendedServiceRepository<TEntity> : IServiceRepository<TEntity>, IAsyncServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
    }
}
