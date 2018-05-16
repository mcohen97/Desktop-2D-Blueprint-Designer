﻿using System;
using System.Runtime.Serialization;

namespace Exceptions {
    public class UserAlreadyExistsException:Exception {

        public UserAlreadyExistsException() {
        }

        public UserAlreadyExistsException(string message) : base(message) {
        }

        public UserAlreadyExistsException(string message, Exception innerException) : base(message, innerException) {
        }

        protected UserAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

    }
}