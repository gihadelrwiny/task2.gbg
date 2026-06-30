using Microsoft.AspNetCore.Mvc;
using task21.Helpers.DTO;
using task21.Models;

namespace task21.Interfaces.IRepository
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentDto> GetAll( string? name, int? minAge, int page, int pageSize);
        public StudentDto GetById(int id);
        public void DeleteStudent(int id);
        public StudentDto CreateStudent(CreateStudentDto dto);
        public void UpdateStudent(int id, UpdateStudentDto dto);
        public int GetStudentGrade(int id);
        public bool EmailExists(string email);
       public bool EmailExists(string email, int excludeId);
    }
}
