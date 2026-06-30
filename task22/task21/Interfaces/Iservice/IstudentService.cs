using task21.Helpers.DTO;
using task21.Models;

namespace task21.Interfaces.Iservice
{
    public interface IstudentService
    {
        public IEnumerable<StudentDto> GetAll(string? name, int? minAge ,int page, int pageSize);
        public StudentDto GetById(int id);
        public void DeleteStudent(int id);
        public StudentDto CreateStudent(CreateStudentDto dto);
        public void UpdateStudent(int id, UpdateStudentDto dto);
        public int GetStudentGrade(int id);
    }
}
