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
        public readonly TService Service;

        public BaseController(TService service)
        {
            Service = service;
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
        public virtual IActionResult GetAll() => Ok(Service.GetAll());

        [HttpGet("get")]
        public virtual IActionResult Get(int id) => Ok(Service.Get(id));

        [HttpPost("add")]
        public virtual IActionResult Add(TModelAdd entity)
        {
            var data = Map<TModelAdd, TEntity>(entity);
            return Ok(Service.Add(data));
        }

        [HttpPost("update")]
        public virtual IActionResult Update(TModelUpdate entity)
        {
            var data = Map<TModelUpdate, TEntity>(entity);
            return Ok(Service.Update(data));
        }

        [HttpPost("delete")]
        public virtual IActionResult Delete(TModelDelete entity)
        {
            var data = Map<TModelDelete, TEntity>(entity);
            return Ok(Service.Delete(data));
        }

        [HttpPost("deleteall")]
        public virtual IActionResult DeleteAll()
        {
            Service.DeleteAll();
            return Ok();
        }

        #endregion

        #region Async

        [HttpGet("getallasync")]
        public async virtual Task<IActionResult> GetAllAsync() => Ok(await Service.GetAllAsync());

        [HttpGet("getasync")]
        public async virtual Task<IActionResult> GetAsync(int id) => Ok(await Service.GetAsync(id));

        [HttpPost("addasync")]
        public async virtual Task<IActionResult> AddAsync(TModelAdd entity)
        {
            var data = Map<TModelAdd, TEntity>(entity);
            return Ok(await Service.AddAsync(data));
        }

        [HttpPost("updateasync")]
        public async virtual Task<IActionResult> UpdateAsync(TModelUpdate entity)
        {
            var data = Map<TModelUpdate, TEntity>(entity);
            return Ok(await Service.UpdateAsync(data));
        }

        [HttpPost("deleteasync")]
        public async virtual Task<IActionResult> DeleteAsync(TModelDelete entity)
        {
            var data = Map<TModelDelete, TEntity>(entity);
            return Ok(await Service.DeleteAsync(data));
        }

        [HttpPost("deleteallasync")]
        public async virtual Task<IActionResult> DeleteAllAsync()
        {
            await Service.DeleteAllAsync();
            return Ok();
        }

        #endregion
    }
}
