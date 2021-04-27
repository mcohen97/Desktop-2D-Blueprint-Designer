using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LogicExceptions
{
    public class InvalidTemplateException:Exception
    {
        public InvalidTemplateException()
        {
        }

        public InvalidTemplateException(string message) : base(message) {
        }

        public InvalidTemplateException(string message, Exception innerException) : base(message, innerException) {
        }

        protected InvalidTemplateException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
