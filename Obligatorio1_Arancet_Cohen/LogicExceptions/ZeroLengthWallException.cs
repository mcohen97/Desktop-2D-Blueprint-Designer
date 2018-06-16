using System;
using System.Runtime.Serialization;

namespace LogicExceptions
{
    public class ZeroLengthWallException : Exception
    {
        public ZeroLengthWallException()
        {
        }

        public ZeroLengthWallException(string message) : base(message)
        {
        }

        public ZeroLengthWallException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroLengthWallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}