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

        public BaseController(TService service)
        {
            _service = service;
        }

        #region Sync

        [HttpGet("getall")]
        public virtual IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("get")]
        public virtual IActionResult Get(int id) => Ok(_service.Get(id));

        [HttpPost("add")]
        public virtual IActionResult Add(TEntity entity) => Ok(_service.Add(entity));

        [HttpPost("update")]
        public virtual IActionResult Update(TEntity entity) => Ok(_service.Update(entity));

        [HttpPost("delete")]
        public virtual IActionResult Delete(TEntity entity) => Ok(_service.Delete(entity));

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
        public async virtual Task<IActionResult> AddAsync(TEntity entity) => Ok(await _service.AddAsync(entity));

        [HttpPost("updateasync")]
        public async virtual Task<IActionResult> UpdateAsync(TEntity entity) => Ok(await _service.UpdateAsync(entity));

        [HttpPost("deleteasync")]
        public async virtual Task<IActionResult> DeleteAsync(TEntity entity) => Ok(await _service.DeleteAsync(entity));

        [HttpPost("deleteallasync")]
        public async virtual Task<IActionResult> DeleteAllAsync()
        {
            await _service.DeleteAllAsync();
            return Ok();
        }

        #endregion
    }
}
