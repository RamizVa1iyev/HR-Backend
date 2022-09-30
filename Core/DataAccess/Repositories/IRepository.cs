using Core.Entities.Abstract;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.Repositories
{
    public interface IRepository<T> : IQuery<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
                         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0, int size = 10,
                         bool enableTracking = true);
        IPaginate<T> GetListByDynamic(Dynamic dynamic,
                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                 int index = 0, int size = 10, bool enableTracking = true);
        T Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        int GetNextId();
        void DeleteAll();
    }
}
