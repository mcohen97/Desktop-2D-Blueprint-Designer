using System;
using System.Runtime.Serialization;

namespace BusinessDataExceptions
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

        public override string ToString()
        {
            return "There is already a template with this name";
        }
    }
}
