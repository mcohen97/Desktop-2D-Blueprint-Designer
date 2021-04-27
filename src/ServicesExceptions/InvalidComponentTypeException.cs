using System;
using System.Runtime.Serialization;

namespace Services
{
    [Serializable]
    public class InvalidComponentTypeException : Exception
    {
        public InvalidComponentTypeException()
        {
        }

        public InvalidComponentTypeException(string message) : base(message)
        {
        }

        public InvalidComponentTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidComponentTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}