using AspnetCoreProject.DAL;
using AspnetCoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreProject.Controllers
{
    //[Authorize]
    [Route("customerapiv2")]
    public class CustomerApiV2Controller : CoreCrudController<Customer, int>
    {
        public CustomerApiV2Controller(ExampleDbContext dbContext) 
        : base(dbContext)
        {
        }        
    }
}