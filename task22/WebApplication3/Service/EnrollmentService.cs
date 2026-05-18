using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Service
{
    public class EnrollmentService
    {
        private readonly SystemContext _context;
    
            public EnrollmentService(SystemContext context)
            {
                _context = context;
            }
        public void EnrollStudent(int studentId, int courseId)
        {
            

            Enrollment enrollment = new Enrollment()
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.Now
            };

            _context.Enrollments.Add(enrollment);

            _context.SaveChanges();
        }
        public void AssignGrade(int enrollmentId, Grade grade)
        {
            var enrollment = _context.Enrollments.Find(enrollmentId);
            if (enrollment != null)
            {
                enrollment.Grade = grade;
                _context.SaveChanges();
            }
        }
        public void GetStudentsInCourse(int courseId)
        {


            var enrollments = _context.Enrollments
                .AsNoTracking()
                .Include(e => e.Student)
                .Where(e => e.CourseId == courseId)
                .ToList();

            foreach (var e in enrollments)
            {
                Console.WriteLine(e.Student.Name);
            }
        }
        public void GetCoursesForStudent(int studentId)
        {


            var enrollments = _context.Enrollments
                .AsNoTracking()
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToList();

            foreach (var e in enrollments)
            {
                Console.WriteLine(e.Course.Title);
            }
        }
        public void GetAverageGrades()
        {
           

            var averages = _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Grade)
                .Where(e => e.Grade != null)
                .GroupBy(e => e.Course.Title)
                .Select(g => new
                {
                    Course = g.Key,
                    Average = g.Average(x => x.Grade.Score)
                })
                .ToList();

            foreach (var item in averages)
            {
                Console.WriteLine($"{item.Course} : {item.Average}");
            }
        }


    }

}
