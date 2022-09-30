using Core.Entities.Abstract;

namespace Core.DataAccess.Repositories
{
    public interface IExtendedRepository<T> : IRepository<T>, IAsyncRepository<T>
        where T : class, IEntity, new()
    {
    }
}
