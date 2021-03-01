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
    public class TaskController : ControllerBase
    {
        public readonly IRepository<TaskModel> _repository;

        public TaskController(IRepository<TaskModel> repository)
        {
            _repository = repository;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public TaskModel Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] TaskModel model)
        {
            if (model == null)
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            return Created("Task", _repository.Add(model));
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskModel model)
        {
            if (model == null)
                return BadRequest();

            var item = _repository.GetById(model.Id);
            if (item == null)
                return NotFound();

            _repository.Update(model);
            return NoContent();
        }

        // DELETE api/<TaskController>/5
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
