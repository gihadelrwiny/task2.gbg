using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task21.Helpers.Data;
using task21.Helpers.DTO;
using task21.Interfaces.Iservice;
using task21.Models;

namespace task21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IstudentService _studentService;
        
        public StudentsController(IstudentService studentservice)
        {
            _studentService = studentservice;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll([FromQuery] string? name, [FromQuery] int? minAge, [FromQuery] int page=1, [FromQuery] int pagesize=0)
        {
            try
            {
                var students = _studentService.GetAll(name, minAge, page, pagesize);
                return Ok(students);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            try
            {
                var student = _studentService.GetById(id);
                return Ok(student);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentDto dto)
        {

            try
            {
                var student = _studentService.CreateStudent(dto);
                return CreatedAtAction(nameof(GetById), new { Id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto dto)
        {
            try
            {
                _studentService.UpdateStudent(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{id}/grade")]
        public IActionResult GetStudentGrade(int id)
        {
            try
            {
                var grade = _studentService.GetStudentGrade(id);
                return Ok(new { grade = grade });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }




    }
}
