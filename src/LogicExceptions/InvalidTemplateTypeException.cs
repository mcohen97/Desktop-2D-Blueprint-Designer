using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicExceptions
{
    public class InvalidTemplateTypeException:InvalidTemplateException
    {
        public InvalidTemplateTypeException()
        {
        }

        public InvalidTemplateTypeException(string message) : base(message) {
        }

        public InvalidTemplateTypeException(string message, Exception innerException) : base(message, innerException) {
        }

        protected InvalidTemplateTypeException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        public override string ToString()
        {
            return "A template cant have this type";
        }
    }

}
