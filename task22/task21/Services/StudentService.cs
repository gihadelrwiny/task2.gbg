using Microsoft.Extensions.Options;
using task21.Helpers.DTO;
using task21.Interfaces.IRepository;
using task21.Interfaces.Iservice;
using task21.Models;

namespace task21.Services
{
    public class StudentService : IstudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly PaginationOptions _paginationOptions;
        private readonly IEmailService _emailService;
        public StudentService(IStudentRepository studentRepository,IOptionsMonitor<PaginationOptions> paginationoption, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _paginationOptions = paginationoption.CurrentValue;
            _emailService = emailService;
        }
        public Student CreateStudent(CreateStudentDto dto)
        {
            var student = _studentRepository.CreateStudent(dto);

            _emailService.SendEmail(student.Email);

            return student;

        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public IEnumerable<Student> GetAll(string? name, int? minAge,int page=1,int pagesize=0)
        {
            Console.WriteLine($"Before: {pagesize}");
            Console.WriteLine($"Default: {_paginationOptions.DefaultPageSize}");

            if (page <= 0) page = 1;
            if (pagesize <= 0) pagesize = _paginationOptions.DefaultPageSize;
            if (pagesize > _paginationOptions.MaxPageSize) pagesize = _paginationOptions.MaxPageSize;
            Console.WriteLine($"After: {pagesize}");

            return _studentRepository.GetAll(name, minAge,page,pagesize);
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public int GetStudentGrade(int id)
        {
            return _studentRepository.GetStudentGrade(id);
        }

        public void UpdateStudent(int id, UpdateStudentDto dto)
        {
            _studentRepository.UpdateStudent(id, dto);
        }
    }
}
