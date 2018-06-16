using System;
using System.Runtime.Serialization;

namespace LogicExceptions
{
    [Serializable]
    public class ComponentInWallException : Exception
    {
        public ComponentInWallException()
        {
        }

        public ComponentInWallException(string message) : base(message)
        {
        }

        public ComponentInWallException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ComponentInWallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}