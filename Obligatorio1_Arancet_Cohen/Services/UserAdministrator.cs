using System;
using System.Collections.Generic;
using Logic.Exceptions;
using Logic.Domain;

namespace Services
{
    public class UserAdministrator
    {
        public Session Session { get; }

        public UserAdministrator(Session aSession)
        {
            Session = aSession;
        }

        public void Add(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_USER))
            {
                throw new NoPermissionsException();
            }
            UsersPortfolio.Instance.Add(aUser);
        }

        public bool Exist(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            return UsersPortfolio.Instance.Exists(aUser);
        }


        public bool ExistsUserName(string userName)
        {//if he needs to know this, he must be trying to create a user
            if (!Session.UserLogged.HasPermission(Permission.CREATE_USER))
            {
                throw new NoPermissionsException();
            }
            return UsersPortfolio.Instance.ExistsUserName(userName);
        }

        public User GetUser(string userName)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }


            return UsersPortfolio.Instance.GetUserByUserName(userName);
        }

        public void Update(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.EDIT_USER))
            {
                throw new NoPermissionsException();
            }
            UsersPortfolio.Instance.Delete(aUser);
            UsersPortfolio.Instance.Add(aUser);
        }

        public void Remove(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.REMOVE_USER))
            {
                throw new NoPermissionsException();
            }
            UsersPortfolio.Instance.Delete(aUser);
        }

        public ICollection<User> GetAllClients()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            ICollection<User> allClients = UsersPortfolio.Instance.GetUsersByPermission(Permission.HAVE_BLUEPRINT);
            return allClients;
        }

        public ICollection<User> GetAllUsersExceptMe()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            ICollection<User> allUsers = UsersPortfolio.Instance.GetAll();
            allUsers.Remove(Session.UserLogged);
            return allUsers;
        }
    }
}