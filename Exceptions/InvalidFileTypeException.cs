namespace WebApplication2.Exceptions;

public class InvalidFileTypeException : Exception
{
    public InvalidFileTypeException(string message) : base(message){}
}