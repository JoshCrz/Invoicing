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
using Service.ViewModels;
using Microsoft.AspNetCore.Cors;
using Service.Commands;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private CustomersService _customerService;

        // Startup.cs -> ConfigureServices, injecting services.
        public CustomersController(CustomersService service)
        {
            _customerService = service;

            // run both to re-create db to latest with some test data. This will run on each call to the api, so comment it out after the first time.
            //_customerService.DeleteAndCreateDatabase();
            //_customerService.SeedTestData();

        }

        // GET: api/Customer
        [HttpGet]
        [HttpOptions]
        public ActionResult Get()
        {
            var query = _customerService.GetAll();
           
            return Ok(query);
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            // find a customer and return
            var query = _customerService.GetSingle(id);
           
            return Ok(query);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult Post([FromBody] CreateCustomerCommand command)
        {
           return  Ok(_customerService.Add(command));
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UpdateCustomerCommand command)
        {
            return Ok(_customerService.Update(id, command));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_customerService.Delete(id));
        }
    }
}
