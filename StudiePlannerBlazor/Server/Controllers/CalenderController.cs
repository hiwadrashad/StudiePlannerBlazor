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
    public class CalenderController : ControllerBase
    {
        public readonly IRepository<CalenderModel> _repository;

        public CalenderController(IRepository<CalenderModel> repository)
        {
            _repository = repository;
        }

        // GET: api/<CalenderController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/<CalenderController>/5
        [HttpGet("{id}")]
        public CalenderModel Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<CalenderController>
        [HttpPost]
        public IActionResult Post([FromBody] CalenderModel model)
        {
            if (model == null)
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            return Created("Calender", _repository.Add(model));
        }

        // PUT api/<CalenderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CalenderModel model)
        {
            if (model == null)
                return BadRequest();

            var item = _repository.GetById(model.Id);
            if (item == null)
                return NotFound();

            _repository.Update(model);
            return NoContent();
        }

        // DELETE api/<CalenderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var model = _repository.GetById(id);

            if (model == null)
                return NotFound();

            _repository.Delete(id);
            return NoContent();
        }
    }
}
