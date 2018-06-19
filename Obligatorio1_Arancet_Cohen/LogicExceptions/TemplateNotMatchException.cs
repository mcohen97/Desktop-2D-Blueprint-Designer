using System;
using System.Runtime.Serialization;

namespace Logic.Domain
{
    [Serializable]
    public class TemplateTypeNotMatchException : Exception
    {
        public TemplateTypeNotMatchException()
        {
        }

        public TemplateTypeNotMatchException(string message) : base(message)
        {
        }

        public TemplateTypeNotMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TemplateTypeNotMatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}