using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime DateOfBirth { get; set; }

    
    public bool IsDeleted { get; set; } = false;

    public List<Enrollment> Enrollments { get; set; }
}