using AutoMapper;
using Core.Business.Abstract;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TService, TEntity, TModelAdd, TModelUpdate, TModelDelete> : ControllerBase
        where TEntity : class, IEntity, new()
        where TModelAdd : class, IAddModel, new()
        where TModelUpdate : class, IUpdateModel, new()
        where TModelDelete : class, IDeleteModel, new()
        where TService : class, IExtendedServiceRepository<TEntity>
    {
        private readonly TService _service;
        private IConfigurationProvider _configurationProvider;

        public BaseController(TService service)
        {
            _service = service;
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

        [HttpGet("getall")]
        public virtual IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("get")]
        public virtual IActionResult Get(int id) => Ok(_service.Get(id));

        [HttpPost("add")]
        public virtual IActionResult Add(TModelAdd entity) 
        {
            var data = Map<TModelAdd, TEntity>(entity);
            return Ok(_service.Add(data)); 
        }

        [HttpPost("update")]
        public virtual IActionResult Update(TModelUpdate entity)
        {
            var data = Map<TModelUpdate, TEntity>(entity);
            return Ok(_service.Update(data));
        }

        [HttpPost("delete")]
        public virtual IActionResult Delete(TModelDelete entity)
        {
            var data = Map<TModelDelete, TEntity>(entity);
            return Ok(_service.Delete(data));
        }

        [HttpPost("deleteall")]
        public virtual IActionResult DeleteAll()
        {
            _service.DeleteAll();
            return Ok();
        }

        #endregion

        #region Async

        [HttpGet("getallasync")]
        public async virtual Task<IActionResult> GetAllAsync() => Ok(await _service.GetAllAsync());

        [HttpGet("getasync")]
        public async virtual Task<IActionResult> GetAsync(int id) => Ok(await _service.GetAsync(id));

        [HttpPost("addasync")]
        public async virtual Task<IActionResult> AddAsync(TModelAdd entity)
        {
            var data = Map<TModelAdd, TEntity>(entity);
            return Ok(await _service.AddAsync(data));
        }

        [HttpPost("updateasync")]
        public async virtual Task<IActionResult> UpdateAsync(TModelUpdate entity)
        {
            var data = Map<TModelUpdate, TEntity>(entity);
            return Ok(await _service.UpdateAsync(data));
        }

        [HttpPost("deleteasync")]
        public async virtual Task<IActionResult> DeleteAsync(TModelDelete entity)
        {
            var data = Map<TModelDelete, TEntity>(entity);
            return Ok(await _service.DeleteAsync(data));
        }

        [HttpPost("deleteallasync")]
        public async virtual Task<IActionResult> DeleteAllAsync()
        {
            await _service.DeleteAllAsync();
            return Ok();
        }

        #endregion
    }
}
