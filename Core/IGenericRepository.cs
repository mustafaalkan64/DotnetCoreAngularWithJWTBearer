using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreProject.Core
{
    public interface IGenericRepository<T, TKey> 
        where T : class
        where TKey : System.IEquatable<TKey>
    {
        Task<DbSet<T>> List();
        Task<T> Get(TKey id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Delete(TKey id);
    }
}