using System;
using System.Runtime.Serialization;

namespace DataAccessExceptions
{
    public class TemplateAlreadyExistsException : Exception
    {
        public TemplateAlreadyExistsException()
        {
        }

        public TemplateAlreadyExistsException(string message) : base(message)
        {
        }

        public TemplateAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
