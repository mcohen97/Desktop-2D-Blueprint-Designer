using System;
using System.Runtime.Serialization;

namespace ServicesExceptions
{
    public class NoPermissionsException : Exception
    {
        public NoPermissionsException()
        {
        }

        public NoPermissionsException(string message) : base(message)
        {
        }

        public NoPermissionsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPermissionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}