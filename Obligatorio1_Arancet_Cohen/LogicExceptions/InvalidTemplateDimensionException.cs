using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LogicExceptions
{
    public class InvalidTemplateDimensionException:InvalidTemplateException
    {
        public InvalidTemplateDimensionException()
        {
        }

        public InvalidTemplateDimensionException(string message) : base(message) {
        }

        public InvalidTemplateDimensionException(string message, Exception innerException) : base(message, innerException) {
        }

        protected InvalidTemplateDimensionException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        public override string ToString()
        {
            return this.Message;
        }
    }
}
