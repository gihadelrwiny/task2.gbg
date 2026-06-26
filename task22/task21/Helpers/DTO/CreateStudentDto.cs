using System.ComponentModel.DataAnnotations;
using task21.Helpers.Attributes;

namespace task21.Helpers.DTO
{
    public class CreateStudentDto
    {
        [Required]
        [NoSpecialCharacters]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(16, 60)]
        public int Age { get; set; }

        public int Grade { get; set; }
    }
}
