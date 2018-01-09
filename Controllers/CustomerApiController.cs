using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreProject.Core;
using AspnetCoreProject.DAL;
using AspnetCoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerApiController : Controller
    {
        private readonly ExampleDbContext _context;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICustomerRepository _repository;

        public CustomerApiController(ExampleDbContext context,
        ICustomerRepository _repository,
        IUnitOfWork unitOfWork)
        {
            this._repository = _repository;
            this.unitOfWork = unitOfWork;
            this._context = context;

            // if (_context.Customers.Count() == 0)
            // {
            //     _context.Customers.Add(new Customer { Name = "Mustafa", Surname = "Alkan", Age = 31 });
            //     _context.SaveChanges();
            // }
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _repository.GetCustomers();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(int id = 0)
        {
            var item = _repository.GetCustomerById(id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (customer == null)
                    return NotFound();

                _repository.Add(customer);
                await this.unitOfWork.CompleteAsync();
                return CreatedAtRoute("GetCustomer", new { id = customer.ID }, customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id = 0)
        {
            try
            {
                var customer = await _repository.GetCustomerById(id);
                if (customer == null)
                    return NotFound();

                _repository.Remove(customer);
                await this.unitOfWork.CompleteAsync();
                return Ok(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer item)
        {
            try
            {
                if (item == null || item.ID != id)
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var customer = await _repository.GetCustomerById(id);
                if (customer == null)
                    return NotFound();

                customer = item;
                _repository.Update(customer);
                await this.unitOfWork.CompleteAsync();
                return Ok(customer);
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                return BadRequest(ModelState);
            }

        }
    }
}
