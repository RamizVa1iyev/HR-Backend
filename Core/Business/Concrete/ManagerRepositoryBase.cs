using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business.Abstract;
using Core.Constants;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Repositories;
using Core.Entities.Abstract;
using Core.Features.Results.Abstract;
using Core.Features.Results.Concrete;
using FluentValidation;

namespace Core.Business.Concrete
{
    public class ManagerRepositoryBase<TEntity, TRepository> : IServiceRepository<TEntity>, IAsyncServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TRepository : class, IExtendedRepository<TEntity>
    {
        private readonly TRepository _repository;
        private IValidator _validator;

        protected ManagerRepositoryBase(TRepository repository)
        {
            _repository = repository;
        }

        protected void SetValidator(IValidator validator)
        {
            _validator = validator;
        }


        #region Sync

        [CacheRemoveAspect("get")]
        public virtual TEntity Add(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return _repository.Add(entity);
        }

        [CacheRemoveAspect("get")]
        public virtual TEntity Delete(TEntity entity) => _repository.Delete(entity);

        [CacheRemoveAspect("get")]
        public virtual void DeleteAll() => _repository.DeleteAll();

        [CacheAspect]
        public virtual TEntity Get(int id) => _repository.Get(e => e.Id == id);

        [CacheAspect]
        public virtual List<TEntity> GetAll() => _repository.GetAll();

        [CacheRemoveAspect("get")]
        public virtual TEntity Update(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return _repository.Update(entity);
        }

        #endregion

        #region Async

        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return await _repository.AddAsync(entity);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            ValidationTool.Validate(_validator, entity);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity) => await _repository.DeleteAsync(entity);

        public async Task DeleteAllAsync() => await _repository.DeleteAllAsync();

        public async Task<List<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<TEntity> GetAsync(int id) => await _repository.GetAsync(e => e.Id == id);

        #endregion
    }
}
