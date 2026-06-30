namespace task21.Helpers.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public int Age { get; set; } = 0;

        public int Grade { get; set; }

        public string FullName { get; set; }

        public string AgeGroup { get; set; }
    }
}