﻿using System;

namespace Logic {
    public class Session {
        public User UserLogged { get;}
        public bool FirstLogin { get; set; }

        internal Session(User aUser) {
            UserLogged = aUser;
            FirstLogin = aUser.LastLoginDate == Constants.NEVER;
            aUser.UpdateLastLoginDate();
        }

    }
}