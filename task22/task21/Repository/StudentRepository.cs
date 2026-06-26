using Microsoft.AspNetCore.Mvc;
using task21.Helpers.Data;
using task21.Helpers.DTO;
using task21.Interfaces.IRepository;
using task21.Models;

namespace task21.Repository
{
    public class StudentRepository : IStudentRepository
    {
     
        public Student CreateStudent(CreateStudentDto dto)
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
            return Student;
        }

        public void DeleteStudent(int id)
        {
            var student = FindStudent(id);
            StudentData.Students.Remove(student);
        }

        public IEnumerable<Student> GetAll(string? name, int? minAge ,int page, int pageSize)
        {


            var students = StudentData.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                students = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (minAge.HasValue)
                students = students.Where(s => s.Age >= minAge.Value);
           
           
            return  students.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public Student GetById(int id)
        {
            var student = FindStudent(id);
            return student;
        }

        public int GetStudentGrade(int id)
        {
            var student = FindStudent(id);
            return student.Grade;
        }

        public void UpdateStudent(int id, UpdateStudentDto dto)
        {
            var student = FindStudent(id);
            if (dto.Name != null)
                student.Name = dto.Name;

            if (dto.Email != null)
                student.Email = dto.Email;

            if (dto.Age.HasValue)
                student.Age = dto.Age.Value;

            if (dto.Grade.HasValue)
                student.Grade = dto.Grade.Value;

        }
        private Student FindStudent(int id)
        {
            return StudentData.Students.FirstOrDefault(s => s.Id == id)
                ?? throw new KeyNotFoundException("Student not found.");
        }
    }
}
