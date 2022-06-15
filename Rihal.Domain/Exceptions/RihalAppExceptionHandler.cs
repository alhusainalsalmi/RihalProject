

namespace Rihal.Domain.Exceptions
{
    public abstract class RihalAppExceptionHandler : Exception
    {

        public RihalAppExceptionHandler(string message) : base(message)
        {
        }
    }
    public class RihalAppNullException : RihalAppExceptionHandler
    {
        public RihalAppNullException(string message) : base(message)
        {

        }
    }
}
