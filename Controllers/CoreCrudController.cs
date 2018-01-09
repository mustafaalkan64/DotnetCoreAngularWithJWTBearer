using System;
using System.Threading.Tasks;
using AspnetCoreProject.Core;
using AspnetCoreProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreProject.Controllers
{
    public class CoreCrudController<T, TKey> : Controller 
        where T : class
        where TKey : IEquatable<TKey>
    {
        private readonly ISimpleCrudService<T, TKey> _crudService;

        public CoreCrudController(ExampleDbContext dbContext)
        {
            _crudService = new SimpleCrudService<T, TKey>(dbContext);
        }
        
        [HttpGet]
        public async Task<object> List()
        {
            return await _crudService.List();
        }
        
        [HttpGet("{id}", Name = "GetCustomerv2")]
        public async Task<object> Get(TKey id)
        {
            try
            {
                if(id == null )
                    return NotFound();
                
                var getModel = _crudService.Get(id);
                if(getModel == null)
                    return NotFound();

                return await getModel;
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<object> Update([FromBody] T model)
        {
            try
            {
                if(model == null)
                    return NotFound();
                    
                await _crudService.Update(model);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(model);
        }
        
        [HttpPost]
        public async Task<object> Create([FromBody] T model)
        {
            try
            {
                await _crudService.Create(model);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok(model);
        }

        [HttpDelete]
        public async Task<object> Delete(TKey id)
        {
            try
            {
                 if(id == null )
                    return NotFound();

                if(_crudService.Get(id) == null)
                    return NotFound();

                await _crudService.Delete(id);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(id);
        }
    }
}