﻿
namespace Logic {
    public class SessionConnector {
        public Session LogIn(string userName, string password) {
            User userLogging = UsersPortfolio.Instance.GetUserByUserName(userName);
            if(userLogging.Password != password) {
                throw new WrongPasswordException();
            }
            return new Session(userLogging);
        }
    }
}