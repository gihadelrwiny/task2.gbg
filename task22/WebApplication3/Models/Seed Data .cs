using System;
using System.Linq;

namespace StudentGradeManagementSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(SystemContext context)
        {
            
          
            if (context.Students.Any())
                return;

            // Students
            var student1 = new Student
            {
                Name = "Ali",
                Email = "ali@gmail.com",
                DateOfBirth = new DateTime(2003, 5, 1)
            };

            var student2 = new Student
            {
                Name = "Sara",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(2004, 8, 10)
            };

            // Courses
            var course1 = new Course
            {
                Title = "Database",
                MaxStudents = 30,
                InstructorName = "Dr.Ahmed"
            };

            var course2 = new Course
            {
                Title = "Algorithms",
                MaxStudents = 25,
                InstructorName = "Dr.Mona"
            };

            context.Students.AddRange(student1, student2);
            context.Courses.AddRange(course1, course2);

            context.SaveChanges();

            // Enrollments
            var enrollment1 = new Enrollment
            {
                StudentId = student1.Id,
                CourseId = course1.Id,
                EnrolledAt = DateTime.Now
            };

            var enrollment2 = new Enrollment
            {
                StudentId = student2.Id,
                CourseId = course1.Id,
                EnrolledAt = DateTime.Now
            };

            var enrollment3 = new Enrollment
            {
                StudentId = student1.Id,
                CourseId = course2.Id,
                EnrolledAt = DateTime.Now
            };

            context.Enrollments.AddRange(
                enrollment1,
                enrollment2,
                enrollment3
            );

            context.SaveChanges();

            // Grades
            var grade1 = new Grade
            {
                EnrollmentId = enrollment1.Id,
                Score = 90,
                GradedAt = DateTime.Now
            };

            var grade2 = new Grade
            {
                EnrollmentId = enrollment2.Id,
                Score = 70,
                GradedAt = DateTime.Now
            };

            var grade3 = new Grade
            {
                EnrollmentId = enrollment3.Id,
                Score = 95,
                GradedAt = DateTime.Now
            };

            context.Grades.AddRange(
                grade1,
                grade2,
                grade3
            );

            context.SaveChanges();
        }
    }
}