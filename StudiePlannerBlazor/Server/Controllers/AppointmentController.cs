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
        public readonly IRepository<AppointmentModel> _repository;

        public AppointmentController(IRepository<AppointmentModel> repository)
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
        public AppointmentModel Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public IActionResult Post([FromBody] AppointmentModel model)
        {
            if (model == null)
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            return Created("Appointment", _repository.Add(model));
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] AppointmentModel model)
        {
            if (model == null)
                return BadRequest(ModelState);

            var item = _repository.GetById(model.Id);
            if (item == null)
                return NotFound();
            _repository.Update(model);
            return NoContent();
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

