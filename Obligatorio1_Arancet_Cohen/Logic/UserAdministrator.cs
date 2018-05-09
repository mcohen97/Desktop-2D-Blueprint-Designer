﻿using Obligatorio1_Arancet_Cohen;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class UserAdministrator
    {
        private List<User> Users;
        private User LoggedUser;
        private User DefaultAdmin;

        public UserAdministrator(User unremovableAdmin)
        {
            Users = new List<User>();
            DefaultAdmin = unremovableAdmin;
            Users.Add(DefaultAdmin);
            LoggedUser = User.NULL_USER;
        }

        public void Login(string userName, string password)
        {
            if (IsUserRegistered(userName))
            {
                User userRegistrated = Users.Find(x => x.UserName.Equals(userName));
                if(userRegistrated.Password == password)
                {
                    LoggedUser = userRegistrated;
                }
            }
        }

        public bool IsUserLogged()
        {
            return !LoggedUser.Equals(User.NULL_USER);
        }

        public void Regist(User user)
        {
            if (LoggedUser.hasPermission(Permission.CREATE_USER))
            {
                Users.Add(user);
            }
        }

        public bool IsUserRegistered(User user)
        {
            return Users.Exists(x => user.Equals(x));
        }

        public bool IsUserRegistered(string userName)
        {
            return Users.Exists(x => x.UserName.Equals(userName));

        }

        public void Logout()
        {
            LoggedUser = User.NULL_USER;
        }

        private bool IsUserDefaultAdmin(User askedUser)
        {
            return DefaultAdmin.Equals(askedUser);
        }

        public void RemoveUser(User userToRemove)
        {
            if (LoggedUser.hasPermission(Permission.REMOVE_USER) && !IsUserDefaultAdmin(userToRemove))
            {
                Users.Remove(userToRemove);
            }
        }

        private User GetUser(User askedUser)
        {
            User returnedUser = null;
            if (IsUserRegistered(askedUser))
            {
                returnedUser = Users.Find(x => askedUser.Equals(x));

            }
            return returnedUser;

        }

        public Client GetClientInfo(User askedClient)
        {
            Client returnedClient = null;
            if (LoggedUser.hasPermission(Permission.READ_USER) || LoggedUser.Equals(askedClient))
            {
                User searchedUser = GetUser(askedClient);
                if (searchedUser is Client)
                {
                    returnedClient = (Client)searchedUser;
                }
            }
            return returnedClient;
        }

        public Designer GetDesignerInfo(User askedDesigner)
        {
            Designer returnedDesigner = null;
            if (LoggedUser.hasPermission(Permission.READ_USER) || LoggedUser.Equals(askedDesigner))
            {
                User searchedUser = GetUser(askedDesigner);
                if (searchedUser is Designer)
                {
                    returnedDesigner = (Designer)searchedUser;
                }
            }
            return returnedDesigner;
        }

        public Admin GetAdminInfo(User askedAdmin)
        {
            Admin returnedAdmin = null;
            if (LoggedUser.hasPermission(Permission.ALL_PERMISSIONS) || LoggedUser.Equals(askedAdmin))
            {
                User searchedUser = GetUser(askedAdmin);
                if (searchedUser is Admin)
                {
                    returnedAdmin = (Admin)searchedUser;
                }
            }
            return returnedAdmin;
        }

        public User GetLoggedUserInfo()
        {
            User returnedUser = null;
            if (IsUserLogged())
            {
                returnedUser = LoggedUser;
            }
            return returnedUser;
        }
    }
}