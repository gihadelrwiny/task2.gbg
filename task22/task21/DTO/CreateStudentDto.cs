using System.ComponentModel.DataAnnotations;

namespace task21.DTO
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(16, 60)]
        public int Age { get; set; }

        public int Grade { get; set; }
    }
}
