using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityModels;
using Repository;
using Service;

using Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private CustomerService _customerService;
        private readonly IMediator _mediator;

        // Startup.cs -> ConfigureServices, injecting services.
        public CustomersController(CustomerService service, IMediator mediator)
        {
            _customerService = service;
            _mediator = mediator;

            // run both to re-create db to latest with some test data. This will run on each call to the api, so comment it out after the first time.
            //_customerService.DeleteAndCreateDatabase();
            //_customerService.SeedTestData();

        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customers>> Get()
        {
            // get all customers and return]#

            //var test = this._mediator.Send(new GetCustomerListQuery());

            return Ok(_customerService.GetAll());
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Customers> Get(int id)
        {
            // find a customer and return
            var customer = _customerService.GetSingle(id);
            if (customer == null)
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
