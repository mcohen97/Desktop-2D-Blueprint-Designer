using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicExceptions
{
    public class InvalidDoorTemplateException: InvalidTemplateException
    {
        public InvalidDoorTemplateException()
        {
        }

        public InvalidDoorTemplateException(string message) : base(message) {
        }

        public InvalidDoorTemplateException(string message, Exception innerException) : base(message, innerException) {
        }

        protected InvalidDoorTemplateException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
