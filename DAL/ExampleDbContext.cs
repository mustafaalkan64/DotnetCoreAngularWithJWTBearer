using AspnetCoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreProject.DAL
{
    public class ExampleDbContext: DbContext
    {

        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
            : base(options)
        { }
         
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Product> Product { get; set;}
        public DbSet<CustomerFavorites> CustomerFavorites { get; set;}
        public DbSet<Category> Category { get; set;}
        public DbSet<SubCategory> SubCategory { get; set;}

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        // {
        //    optionsBuilder.UseSqlServer("server=localhost;Database=AspnetCoreExampleDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        // }
    }

}