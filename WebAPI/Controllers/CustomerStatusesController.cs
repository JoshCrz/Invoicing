using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.CustomerStatuses;
using Service.Queries;
using Service.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerStatusesController : ControllerBase
    {

        private CustomerStatusService _statusService;

        public CustomerStatusesController(CustomerStatusService service)
        {
            _statusService = service;

        }

        // GET: api/<CustomerStatusesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_statusService.GetAll(new GetCustomerStatusListQuery()));
        }

        // GET api/<CustomerStatusesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_statusService.GetSingle(new GetCustomerStatusDetailsQuery(id)));
        }

        // POST api/<CustomerStatusesController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateCustomerStatusCommand command)
        {
            return Ok(_statusService.CreateStatus(command));
        }

        // PUT api/<CustomerStatusesController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UpdateCustomerStatusCommand command)
        {
            return Ok(_statusService.UpdateStatus(command));
        }

        // DELETE api/<CustomerStatusesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromBody] DeleteCustomerStatusCommand command)
        {
            return Ok(_statusService.DeleteStatus(command));

        }
    }
}
