using Microsoft.AspNetCore.Mvc;
using StudiePlannerBlazor.Server.Repositories;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudiePlannerBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public readonly IRepository<Appointment> _repository;

        public AppointmentController(IRepository<Appointment> repository)
        {
            _repository = repository;
        }
        // GET: api/<AppointmentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Appointment Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Appointment model)
        {
            if (model == null)
            return 
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
