﻿using System;

namespace Logic {
    public class UserAdministrator {
        public Session Session { get; }

        public UserAdministrator(Session aSession) {
            Session = aSession;
        }

        public void Add(User aUser) {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_USER)) {
                throw new NoPermissionsException();
            }
            UsersPortfolio.Instance.Add(aUser);
        }

        public bool Exist(User aUser) {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER)) {
                throw new NoPermissionsException();
            }
            return UsersPortfolio.Instance.Exist(aUser);
        }

        public User GetUser(string userName) {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER)) {
                throw new NoPermissionsException();
            }


            return UsersPortfolio.Instance.GetUserByUserName(userName);
        }

        public void Update(User aUser) {
            if (!Session.UserLogged.HasPermission(Permission.EDIT_USER)) {
                throw new NoPermissionsException();
            }
            UsersPortfolio.Instance.Remove(aUser);
            UsersPortfolio.Instance.Add(aUser);
        }

        public void Remove(User aUser) {
            if (!Session.UserLogged.HasPermission(Permission.REMOVE_USER)) {
                throw new NoPermissionsException();
            }
            UsersPortfolio.Instance.Remove(aUser);
        }
    }
}