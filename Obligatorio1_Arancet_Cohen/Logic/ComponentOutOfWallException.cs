using System;
using System.Runtime.Serialization;

namespace Exceptions {
    public class ComponentOutOfWallException: Exception {
        public ComponentOutOfWallException() {
        }

        public ComponentOutOfWallException(string message) : base(message) {
        }

        public ComponentOutOfWallException(string message, Exception innerException) : base(message, innerException) {
        }

        protected ComponentOutOfWallException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}