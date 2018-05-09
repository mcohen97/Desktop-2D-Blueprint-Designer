using System;
using System.Runtime.Serialization;

namespace Logic {
    public class CollinearWallsException:WallsDoNotIntersectException {
        public CollinearWallsException() {
        }

        public CollinearWallsException(string message) : base(message) {
        }

        public CollinearWallsException(string message, Exception innerException) : base(message, innerException) {
        }

        protected CollinearWallsException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
