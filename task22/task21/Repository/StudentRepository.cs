using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using task21.Helpers.Data;
using task21.Helpers.DTO;
using task21.Helpers.Exceptions;
using task21.Interfaces.IRepository;
using task21.Models;

namespace task21.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMapper _mapper;
        public StudentRepository(IMapper  mapper)
        {
            _mapper = mapper;
        }

        public StudentDto CreateStudent(CreateStudentDto dto)
        {
           var student = _mapper.Map < Student >(dto);
            student.Id = StudentData.Students.Any() ? StudentData.Students.Max(s => s.Id) + 1 : 1;
            StudentData.Students.Add(student);
            var studentdto = _mapper.Map<StudentDto>(student);
            return studentdto;
        }

        public void DeleteStudent(int id)
        {
            var student = FindStudent(id);
            StudentData.Students.Remove(student);
        }

        public IEnumerable<StudentDto> GetAll(string? name, int? minAge ,int page, int pageSize)
        {

            var students = StudentData.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                students = students.Where(s => (s.FirstName + " " + s.LastName).Equals(name, StringComparison.OrdinalIgnoreCase));

            if (minAge.HasValue)
                students = students.Where(s => s.Age >= minAge.Value);
            var studentsPagination = students
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();

            return _mapper.Map<List<StudentDto>>(studentsPagination);
        }

        public StudentDto GetById(int id)
        {
            var student = FindStudent(id);
            var studentdto = _mapper.Map<StudentDto>(student);
            return studentdto;
        }

        public int GetStudentGrade(int id)
        {
            var student = FindStudent(id);
            return student.Grade;
        }

        public void UpdateStudent(int id, UpdateStudentDto dto)
        {
            var student = FindStudent(id);
            _mapper.Map(dto, student);
        }
        private Student FindStudent(int id)
        {
            return StudentData.Students.FirstOrDefault(s => s.Id == id)
                ?? throw new NotFoundException($"Student with id {id} was not found.");
        }
        public bool EmailExists(string email)
        {
            return StudentData.Students.Any(s => s.Email == email);
        }
        public bool EmailExists(string email, int excludeId)
        {
            return StudentData.Students.Any(s =>
                s.Email == email && s.Id != excludeId);
        }
    }

}
