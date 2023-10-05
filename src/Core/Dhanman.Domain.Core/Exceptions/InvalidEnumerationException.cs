namespace Dhanman.Domain.Core.Exceptions;

public sealed class InvalidEnumerationException : Exception
{
    public InvalidEnumerationException()
        : base("The specified type is not a valid enumeration type.")
    {
    }
}
