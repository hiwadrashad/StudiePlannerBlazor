using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudiePlannerBlazor.Server.Repositories;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        public readonly IRepository<DocumentModel> _repository;

        public FileController(IRepository<DocumentModel> repository)
        {
            _repository = repository;
        }

        // GET: api/<FileController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public DocumentModel Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST: api/<FileController>
        [HttpPost]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var document = _repository.Add(new DocumentModel { Path = dbPath });

                    return Ok(document);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var model = _repository.GetById(id);

            System.IO.File.Delete(model.Path);

            if (model == null)
                return NotFound();

            _repository.Delete(id);
            return NoContent();
        }
    }
}
