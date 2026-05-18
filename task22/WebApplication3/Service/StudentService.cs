

using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Service
{
    public class StudentService
    {
        private readonly SystemContext _context;
    
            public StudentService(SystemContext context)
            {
                _context = context;
            }
    
            public List<Student> GetAllStudents()
            {
                return _context.Students.AsNoTracking().ToList();
            }
    
            public Student GetStudentById(int id)
            {
                return _context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            }
    
            public void AddStudent(Student student)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }


        public void UpdateStudent(Student student)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
            }
    
            public void DeleteStudent(int id)
            {
                var student = _context.Students.Find(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
            }
    }
}
