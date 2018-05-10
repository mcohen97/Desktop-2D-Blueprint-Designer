using System;
using System.Runtime.Serialization;

namespace Logic {
    public class OutOfRangeComponentException: Exception {
        public OutOfRangeComponentException() {
        }

        public OutOfRangeComponentException(string message) : base(message) {
        }

        public OutOfRangeComponentException(string message, Exception innerException) : base(message, innerException) {
        }

        protected OutOfRangeComponentException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}