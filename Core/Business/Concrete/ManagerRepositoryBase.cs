using Core.Aspects.Autofac.Caching;
using Core.Business.Abstract;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Repositories;
using Core.Entities.Abstract;
using FluentValidation;

namespace Core.Business.Concrete
{
    public class ManagerRepositoryBase<TEntity, TRepository> : IServiceRepository<TEntity>, IAsyncServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TRepository : class, IExtendedRepository<TEntity>
    {
        public readonly TRepository Repository;
        private IValidator _validator;

        public ManagerRepositoryBase(TRepository repository)
        {
            Repository = repository;
        }

        protected void SetValidator(IValidator validator)
        {
            _validator = validator;
        }

        protected TTarget Map<TCurrent, TTarget>(TCurrent source)
        {
            var data = Activator.CreateInstance<TTarget>();

            var targetProperties = source.GetType().GetProperties();
            var destinationProperties = data.GetType().GetProperties();

            foreach (var dp in destinationProperties)
            {
                var val = targetProperties.FirstOrDefault(p => p.Name == dp.Name)?.GetValue(source);
                dp.SetValue(data, val);
            }

            return data;
        }

        #region Sync

        [CacheRemoveAspect("get")]
        public virtual TEntity Add(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return Repository.Add(entity);
        }

        [CacheRemoveAspect("get")]
        public virtual TEntity Delete(TEntity entity) => Repository.Delete(entity);

        [CacheRemoveAspect("get")]
        public virtual void DeleteAll() => Repository.DeleteAll();

        [CacheAspect]
        public virtual TEntity Get(int id) => Repository.Get(e => e.Id == id);

        [CacheAspect]
        public virtual List<TEntity> GetAll() => Repository.GetAll();

        [CacheRemoveAspect("get")]
        public virtual TEntity Update(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return Repository.Update(entity);
        }

        #endregion

        #region Async

        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return await Repository.AddAsync(entity);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return await Repository.UpdateAsync(entity);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity) => await Repository.DeleteAsync(entity);

        public async Task DeleteAllAsync() => await Repository.DeleteAllAsync();

        public async Task<List<TEntity>> GetAllAsync() => await Repository.GetAllAsync();

        public async Task<TEntity> GetAsync(int id) => await Repository.GetAsync(e => e.Id == id);

        #endregion
    }
}
