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

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_customerService.GetAll(new GetCustomerListQuery()));
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok(_customerService.GetSingle(new GetCustomerDetailsQuery(id)));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateCustomerCommand command)
        {
           return  Ok(_customerService.CreateCustomer(command));
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UpdateCustomerCommand command)
        {
            return Ok(_customerService.UpdateCustomer(id, command));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromBody] DeleteCustomerCommand command)
        {
            return Ok(_customerService.DeleteCustomer(id, command));
        }

        //[HttpPost("{id}/AddAddress")]
        //public ActionResult AddAddress(int id, [FromBody] CreateAddressCommand command)
        //{
        //    return Ok(_customerService.AddCustomerAddress(id, command));
        //}

        //[HttpPut("{id}/UpdateAddress")]
        //public ActionResult UpdateAddress(int id, [FromBody] UpdateAddressCommand command)
        //{
        //    return Ok(_customerService.UpdateCustomerAddress(id, command));
        //}

        //[HttpDelete("{id}/RemoveAddress")]
        //public ActionResult RemoveAddress(int id, [FromBody] DeleteAddressCommand command)
        //{
        //    return Ok(_customerService.RemoveCustomerAddress(id, command));
        //}

        //[HttpPost("{id}/AddStatus")]
        //public ActionResult AddStatus(int id, [FromBody] CreateCustomerStatusCommand command)
        //{
        //    return Ok(_customerService.AddCustomerStatus(id, command));
        //}

        //[HttpPut("{id}/UpdateStatus")]
        //public ActionResult UpdateStatus(int id, [FromBody] UpdateCustomerStatusCommand command)
        //{
        //    return Ok(_customerService.UpdateCustomerStatus(id, command));
        //}

        //[HttpDelete("{id}/RemoveStatus")]
        //public ActionResult RemoveStatus(int id, [FromBody] DeleteCustomerStatusCommand command)
        //{
        //    return Ok(_customerService.RemoveCustomerStatus(id, command));
        //}

    }
}
