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
           
                var students = _studentService.GetAll(name, minAge, page, pagesize);
                return Ok(students);         
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
                var student = _studentService.GetById(id);
                return Ok(student);
                    
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
             _studentService.DeleteStudent(id);
                return NoContent();

        }
        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentDto dto)
        {
                var student = _studentService.CreateStudent(dto);
                return CreatedAtAction(nameof(GetById), new { Id = student.Id }, student);
            

        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto dto)
        {

                _studentService.UpdateStudent(id, dto);
                return NoContent();
        }
        [HttpGet("{id}/grade")]
        public IActionResult GetStudentGrade(int id)
        {

                var grade = _studentService.GetStudentGrade(id);
                return Ok(new { grade = grade });

        }




    }
}
