using System;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreProject.Core;

namespace AspnetCoreProject.DAL
{
    public class SimpleCrudService<T, TKey> : ISimpleCrudService<T, TKey>  
        where T : class
        where TKey : IEquatable<TKey>
    {
        private readonly IGenericRepository<T, TKey> _repository;
        
        public SimpleCrudService(ExampleDbContext dbContext)
        {
            _repository = new GenericRepository<T, TKey>(dbContext);   
        }
        
        public async Task<IQueryable<T>> List()
        {
            return await _repository.List();
        }

        public async Task<T> Get(TKey id)
        {
            return await _repository.Get(id);
        }

        public async Task Create(T t)
        {
            await _repository.Create(t);
        }

        public async Task Update(T t)
        {
            await _repository.Update(t);
        }

        public async Task Delete(TKey id)
        {
            await _repository.Delete(id);
        }
    }
}