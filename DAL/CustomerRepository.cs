using AspnetCoreProject.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AspnetCoreProject.Core;

namespace AspnetCoreProject.DAL
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ExampleDbContext context;
        public CustomerRepository(ExampleDbContext context)
        {
            this.context = context;
        }

        public async Task<Customer> GetCustomerById(int id = 0)
        {
            return await context.Customers
                .Include(v => v.CustomerFavorites)
                .AsNoTracking()
                .SingleOrDefaultAsync(v => v.ID == id);
        }

        public void Add(Customer customer) 
        {
            context.Customers.Add(customer);
        }

        public void Update(Customer customer) 
        {
            context.Customers.Update(customer);
        }

        public void Remove(Customer customer) 
        {
            context.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await context.Customers
            .Include(v => v.CustomerFavorites)
            .ToListAsync();
        }
    }
}