using System.ComponentModel.DataAnnotations;

namespace task21.Helpers.DTO
{
    public class UpdateStudentDto
    {
      
            public string? Name { get; set; }

            [EmailAddress]
            public string? Email { get; set; }

            [Range(16, 60)]
            public int? Age { get; set; }

            public int? Grade { get; set; }
        
    }
}
