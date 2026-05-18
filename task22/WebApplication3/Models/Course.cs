using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public int MaxStudents { get; set; }

    public string InstructorName { get; set; }

    public List<Enrollment> Enrollments { get; set; }
}