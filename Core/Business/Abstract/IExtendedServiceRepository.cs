using Core.Entities.Abstract;

namespace Core.Business.Abstract
{
    public interface IExtendedServiceRepository<T> : IServiceRepository<T>, IAsyncServiceRepository<T>
        where T : class, IEntity, new()
    {
    }
}
