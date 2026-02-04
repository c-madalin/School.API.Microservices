using Microsoft.AspNetCore.Mvc;
using School.API.Dto;
using School.API.Service;

namespace School.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var studenti = _service.ObtineTotiStudentii();
            return Ok(studenti); 
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDto studentDto)
        {
            try
            {
                _service.AdaugaStudent(studentDto.Nume, studentDto.Nota);
                return Ok(new { message = "Adaugat cu succes!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.StergeStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            try
            {
                var count = _service.ObtineTotiStudentii().Count;
                return Ok(new { message = "Database connected!", studentCount = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }

   
}