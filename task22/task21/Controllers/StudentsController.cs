using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task21.Data;
using task21.DTO;
using task21.Models;

namespace task21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll([FromQuery] string? name, [FromQuery] int? minAge)
        {
            var students = StudentData.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                students = students.Where(s => s.Name == name);

            if (minAge.HasValue)
                students = students.Where(s => s.Age >= minAge);

            return Ok(students);
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = StudentData.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var Student = StudentData.Students.FirstOrDefault(s => s.Id == id);
            if (Student == null) return NotFound();
            StudentData.Students.Remove(Student);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentDto dto)
        {
            var Student = new Student
            {
                Id = StudentData.Students.Any() ? StudentData.Students.Max(s => s.Id) + 1 : 1,
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Grade = dto.Grade

            };
            StudentData.Students.Add(Student);
            return CreatedAtAction(nameof(GetById), new { Id = Student.Id }, Student);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto dto)
        {
            var student = StudentData.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            if (dto.Name != null)
                student.Name = dto.Name;

            if (dto.Email != null)
                student.Email = dto.Email;

            if (dto.Age.HasValue)
                student.Age = dto.Age.Value;

            if (dto.Grade.HasValue)
                student.Grade = dto.Grade.Value;
            return NoContent();
        }
        [HttpGet("{id}/grade")]
        public IActionResult GetStudentGrade(int id)
        {
            var student = StudentData.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(new { grade = student.Grade });

        }




    }
}
