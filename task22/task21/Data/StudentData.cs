using task21.Models;

namespace task21.Data
{
    public static class StudentData
    {
        public static List<Student> Students = new List<Student>
        {
            new Student { Id = 1, Name = "Ahmed Ali", Email = "ahmed@example.com", Age = 20, Grade = 85 },
            new Student { Id = 2, Name = "Sara Mohamed", Email = "sara@example.com", Age = 21, Grade = 90 },
            new Student { Id = 3, Name = "Omar Hassan", Email = "omar@example.com", Age = 22, Grade = 78 }
        };
    }
}
