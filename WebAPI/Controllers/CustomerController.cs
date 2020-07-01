using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityModels;   

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private List<Customers> customers;
        public CustomerController()
        {
            customers = new List<Customers>();
            customers.Add(new Customers() { CustomerID = 1, CompanyName = "Company number 1" });
            customers.Add(new Customers() { CustomerID = 2, CompanyName = "Company number 2" });
            customers.Add(new Customers() { CustomerID = 3, CompanyName = "Company number 3" });
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customers Get(int id)
        {

            var customer = customers.Where(x => x.CustomerID == id).FirstOrDefault();
            if(customer == null)
            {
                throw new Exception("Customer not found");
            }

            return customer;
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
