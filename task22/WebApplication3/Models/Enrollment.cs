using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

public class Enrollment
{
    [Key]
    public int Id { get; set; }
     [ForeignKey("Student")]
    public int StudentId { get; set; }

    public Student Student { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }

    public Course Course { get; set; }

    public DateTime EnrolledAt { get; set; }

    public Grade Grade { get; set; }
}