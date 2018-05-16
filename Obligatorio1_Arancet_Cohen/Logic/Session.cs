using System;

namespace Domain {
    public class Session {
        public User UserLogged { get;}

        internal Session(User aUser) {
            UserLogged = aUser;
        }

    }
}