using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using task21.EventArguments;
using task21.Helpers.DTO;
using task21.Helpers.Exceptions;
using task21.Interfaces;
using task21.Interfaces.IRepository;
using task21.Interfaces.Iservice;
using task21.Models;

namespace task21.Services
{
    public class StudentService : IstudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly PaginationOptions _paginationOptions;
        private readonly IEventBus _eventBus;
        private readonly ILogger<StudentService> _logger;
        public event EventHandler<StudentRegisteredEventArgs>? StudentRegisteredEvent;
        public StudentService(IStudentRepository studentRepository,IOptionsMonitor<PaginationOptions> paginationoption, ILogger<StudentService> logger ,
            EmailNotificationService emailNotificationService, LoggerSubscriber loggerSubscriber, IEventBus eventBus)
        {
            _studentRepository = studentRepository;
            _paginationOptions = paginationoption.CurrentValue;    
            _logger = logger;
            _eventBus = eventBus;
           
        }
        public StudentDto CreateStudent(CreateStudentDto dto)
        {

            CheckEmailExists(dto.Email);
            // Business Rule 
            ValidateStudent(dto.Age, dto.Grade);
            var studentdto = _studentRepository.CreateStudent(dto);
            _logger.LogInformation("Student {id} Created ", studentdto.Id);

            _eventBus.Publish(new StudentRegisteredEventArgs(studentdto));
            return studentdto;

        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
            _logger.LogInformation("Student {Id} deleted.", id);
        }

        public IEnumerable<StudentDto> GetAll(string? name, int? minAge,int page=1,int pagesize=0)
        {
            Console.WriteLine($"Before: {pagesize}");
            Console.WriteLine($"Default: {_paginationOptions.DefaultPageSize}");

            if (page <= 0) page = 1;
            if (pagesize <= 0) pagesize = _paginationOptions.DefaultPageSize;
            if (pagesize > _paginationOptions.MaxPageSize) pagesize = _paginationOptions.MaxPageSize;
            Console.WriteLine($"After: {pagesize}");

            return _studentRepository.GetAll(name, minAge,page,pagesize);
        }

        public StudentDto GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public int GetStudentGrade(int id)
        {
            return _studentRepository.GetStudentGrade(id);
        }

        public void UpdateStudent(int id, UpdateStudentDto dto)
        {
            if (dto.Email != null)
            {
                CheckEmailExists(dto.Email, id);
            }
            var student = _studentRepository.GetById(id);
            var age = dto.Age ?? student.Age;
            var grade = dto.Grade ?? student.Grade;
            //business rule: Students under 21 cannot have a grade above 90
            ValidateStudent(age, grade);
            _studentRepository.UpdateStudent(id, dto);
            _logger.LogInformation("Student {id} Updated ", student.Id);
        }
        private void CheckEmailExists(string email, int? excludeId = null)
        {
            bool exists = excludeId.HasValue
                ? _studentRepository.EmailExists(email, excludeId.Value)
                : _studentRepository.EmailExists(email);
            if (exists)
            {
                var ex = new ConflictException("Email already exists.");
                _logger.LogError(ex,"Duplicate email detected: {Email}", email);
                throw ex;
            }
        }
        private void ValidateStudent(int age, int grade)
        {
            if (age < 21 && grade > 90)
            {
                var ex = new ValidationException( "Students under 21 cannot have a grade above 90.");
                _logger.LogError(ex, "Validation failed. Age: {Age}, Grade: {Grade}", age, grade);
                throw ex;
            }
        }
    }
}
