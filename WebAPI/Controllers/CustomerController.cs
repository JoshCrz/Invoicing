using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityModels;
using Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private CustomerContext _db;

        // Startup.cs -> ConfigureServices, injecting customer context.
        public CustomerController(CustomerContext customerContext) 
        {
            _db = customerContext;
            //_db.Database.EnsureCreated();
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customers>> Get()
        {
            // get all customers and return
            return Ok(_db.Customers.ToList());
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Customers> Get(int id)
        {
            // find a customer (or null) and return
            var customer = _db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
