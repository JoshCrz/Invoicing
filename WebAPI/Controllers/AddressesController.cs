using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Addresses;
using Service.Commands;
using Service.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {

        private AddressesService _addressService;
        public AddressesController(AddressesService service)
        {
            _addressService = service;
        }


        // GET: api/<AddressesController>
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_addressService.GetAll(new GetAddressListQuery()));
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public ActionResult GetSingle(int id)
        {
            return Ok(_addressService.GetSingle(new GetAddressDetailsQuery(id)));
        }

        // POST api/<AddressesController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateAddressCommand command)
        {
            return Ok(_addressService.CreateStatus(command));
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UpdateAddressCommand command)
        {
            return Ok(_addressService.UpdateStatus(command));
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromBody] DeleteAddressCommand command)
        {
            return Ok(_addressService.DeleteStatus(command));
        }
    }
}
