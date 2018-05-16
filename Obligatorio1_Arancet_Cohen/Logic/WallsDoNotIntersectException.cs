using System;
using System.Runtime.Serialization;

namespace Exceptions {
    public class WallsDoNotIntersectException : Exception {
        public WallsDoNotIntersectException() {
        }

        public WallsDoNotIntersectException(string message) : base(message) {
        }

        public WallsDoNotIntersectException(string message, Exception innerException) : base(message, innerException) {
        }

        protected WallsDoNotIntersectException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}