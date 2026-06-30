namespace task21.Helpers.Exceptions
{
    public class ConflictException:Exception
    {
        public ConflictException() { }
        public ConflictException(string msg):base(msg) { }
    }
}
