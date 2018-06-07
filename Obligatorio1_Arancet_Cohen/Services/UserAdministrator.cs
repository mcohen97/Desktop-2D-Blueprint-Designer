using System;
using System.Collections.Generic;
using Logic.Exceptions;
using Logic.Domain;
using DataAccess;
using RepositoryInterface;
using UserRepositoryInterface;

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
            IRepository<User> usersStorage = new UserRepository();
            usersStorage.Add(aUser);
        }

        public bool Exist(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            IRepository<User> usersStorage = new UserRepository();
            return usersStorage.Exists(aUser);
        }


        public bool ExistsUserName(string userName)
        {//if he needs to know this, he must be trying to create a user
            if (!Session.UserLogged.HasPermission(Permission.CREATE_USER))
            {
                throw new NoPermissionsException();
            }
            IUserRepository usersStorage = new UserRepository();
            return usersStorage.ExistsUserName(userName);
        }

        public User GetUser(string userName)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            IUserRepository usersStorage = new UserRepository();
            return usersStorage.GetUserByUserName(userName);
        }

        public void Update(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.EDIT_USER))
            {
                throw new NoPermissionsException();
            }
            IRepository<User> usersStorage = new UserRepository();
            usersStorage.Modify(aUser);
        }

        public void Remove(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.REMOVE_USER))
            {
                throw new NoPermissionsException();
            }
            IRepository<User> usersStorage = new UserRepository();
            usersStorage.Delete(aUser);
        }

        public ICollection<User> GetAllClients()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            IUserRepository usersStorage = new UserRepository();
            ICollection<User> allClients = usersStorage.GetUsersByPermission(Permission.HAVE_BLUEPRINT);
            return allClients;
        }

        public ICollection<User> GetAllUsersExceptMe()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            IRepository<User> usersStorage = new UserRepository();
            ICollection<User> allUsers = usersStorage.GetAll();
            allUsers.Remove(Session.UserLogged);
            return allUsers;
        }
    }
}