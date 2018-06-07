using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Logic.Exceptions;

[assembly: InternalsVisibleTo("SystemLoginTest")]
[assembly: InternalsVisibleTo("SystemUsersTest")]

namespace Logic.Domain
{
    public class UsersPortfolio
    {

        private static UsersPortfolio instance;
        private ICollection<User> Users;

        public static UsersPortfolio Instance {
            get {
                if (instance == null)
                {
                    instance = new UsersPortfolio();
                    instance.Add(new Admin("admin", "admin", "admin", "admin", DateTime.Now));
                }
                return instance;
            }
        }

        private UsersPortfolio()
        {
            Users = new List<User>();
        }
        public bool IsEmpty()
        {
            return Users.Count() == 1;
        }

        public void Add(User userToAdd)
        {
            if (userToAdd == null)
            {
                throw new ArgumentNullException();
            }
            if (Exists(userToAdd))
            {
                throw new UserAlreadyExistsException();
            }
            Users.Add(userToAdd);
        }

        public bool Delete(User userToRemove)
        {
            if (userToRemove == null)
            {
                throw new ArgumentNullException();
            }

            bool wasRemoved = Users.Remove(userToRemove);
            if (wasRemoved && userToRemove.HasPermission(Permission.HAVE_BLUEPRINT))
            {
                BlueprintPortfolio.Instance.DeleteUserBlueprints((Client)userToRemove);
            }
            return wasRemoved;
        }

        public bool Exists(User userAsked)
        {
            if (userAsked == null)
            {
                throw new ArgumentNullException();
            }
            return Users.Contains(userAsked);
        }

        public void Clear()
        {
            Users = new List<User>();
            Users.Add(new Admin("admin", "admin", "admin", "admin", DateTime.Now));
        }

        public bool ExistsUserName(string aUserName)
        {
            return Users.Any(u => u.UserName.Equals(aUserName));
        }

        public User Get(User userAsked)
        {
            return Users.First(x => userAsked.Equals(x));
        }

        public ICollection<User> GetAll()
        {
            return (ICollection<User>)(new List<User>(Users));
        }   

        public User GetUserByUserName(string userName)
        {
            try
            {
                return Users.First(x => x.UserName == userName);
            }
            catch (Exception)
            {
                throw new UserNotFoundException();
            }
        }

        public ICollection<User> GetUsersByPermission(Permission aFeature)
        {
            return (ICollection<User>)GetAll().Where(u => u.HasPermission(aFeature)).ToList();
        }
    }
}