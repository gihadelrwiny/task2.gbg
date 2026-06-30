using task21.Helpers.DTO;

namespace task21.EventArguments
{
    public class StudentRegisteredEventArgs
    {

        public StudentDto Student { get; }

        public StudentRegisteredEventArgs(StudentDto student)
        {
            Student = student;
        }
    }
}
