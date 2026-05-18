using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Grade
{
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Enrollment")]
    public int EnrollmentId { get; set; }

    public Enrollment Enrollment { get; set; }

    public double Score { get; set; }

    public DateTime GradedAt { get; set; }
}