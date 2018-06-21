using System;
using System.Runtime.Serialization;

namespace BusinessDataExceptions
{
    public class TemplateDoesNotExistException:Exception
    {
        public TemplateDoesNotExistException()
        {
        }

        public TemplateDoesNotExistException(string message) : base(message)
        {
        }

        public TemplateDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
