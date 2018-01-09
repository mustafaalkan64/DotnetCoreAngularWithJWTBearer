using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetCoreProject.Models;

namespace AspnetCoreProject.Core
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(int id = 0);
        void Add(Customer customer);
        void Remove(Customer customer);
        void Update(Customer customer);
        Task<IEnumerable<Customer>> GetCustomers();
    }
}