using System;
using System.Runtime.Serialization;

namespace LogicExceptions
{
    [Serializable]
    public class ColumnInPlaceException : Exception
    {
        public ColumnInPlaceException()
        {
        }

        public ColumnInPlaceException(string message) : base(message)
        {
        }

        public ColumnInPlaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ColumnInPlaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}