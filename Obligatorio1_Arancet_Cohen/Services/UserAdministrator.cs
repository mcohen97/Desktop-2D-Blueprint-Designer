using System;
using System.Collections.Generic;
using Logic.Domain;
using RepositoryInterface;
using DomainRepositoryInterface;
using ServicesExceptions;

namespace Services
{
    public class UserAdministrator
    {
        public Session Session { get; }
        IRepository<User> usersStorage;

        public UserAdministrator(Session aSession, IRepository<User> aRepository)
        {
            Session = aSession;
            usersStorage = aRepository;
        }

        public void Add(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_USER))
            {
                throw new NoPermissionsException();
            }
            usersStorage.Add(aUser);
        }

        public bool Exist(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            return usersStorage.Exists(aUser);
        }


        public bool ExistsUserName(string userName)
        {//if he needs to know this, he must be trying to create a user
            if (!Session.UserLogged.HasPermission(Permission.CREATE_USER))
            {
                throw new NoPermissionsException();
            }
            return ((IUserRepository)usersStorage).ExistsUserName(userName);
        }

        public User GetUser(string userName)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            return ((IUserRepository)usersStorage).GetUserByUserName(userName);
        }

        public void Update(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.EDIT_USER))
            {
                throw new NoPermissionsException();
            }
            usersStorage.Modify(aUser);
        }

        public void Remove(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.REMOVE_USER))
            {
                throw new NoPermissionsException();
            }
            usersStorage.Delete(aUser);
        }

        public ICollection<User> GetAllClients()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            ICollection<User> allClients = ((IUserRepository)usersStorage).GetUsersByPermission(Permission.HAVE_BLUEPRINT);
            return allClients;
        }

        public ICollection<User> GetAllUsersExceptMe()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            ICollection<User> allUsers = usersStorage.GetAll();
            allUsers.Remove(Session.UserLogged);
            return allUsers;
        }

        public ICollection<User> GetUsersByPermission(Permission aPermission)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_USER))
            {
                throw new NoPermissionsException();
            }
            return ((IUserRepository)usersStorage).GetUsersByPermission(aPermission);
        }
    }
}