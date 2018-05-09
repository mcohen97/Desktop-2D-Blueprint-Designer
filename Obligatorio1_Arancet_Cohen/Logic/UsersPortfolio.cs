﻿using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly: InternalsVisibleTo("SystemLoginTest")]
[assembly: InternalsVisibleTo("SystemUsersTest")]

namespace Logic {
    internal class UsersPortfolio {

        private static UsersPortfolio instance;
        private ICollection<User> Users;

        public static UsersPortfolio Instance {
            get {
                if(instance == null) {
                    instance = new UsersPortfolio();
                    instance.Add(new Admin("admin", "admin", "admin", "admin", DateTime.Now));
                }
                return instance;
            }
        }

        private UsersPortfolio() {
            Users = new List<User>();
        }
        public bool IsEmpty() {
            return Users.Count() == 1;
        }

        public void Add(User userToAdd) {
            if (userToAdd == null) {
                throw new ArgumentNullException();
            }
            Users.Add(userToAdd);
        }

        public bool Remove(User userToRemove) {
            if (userToRemove == null) {
                throw new ArgumentNullException();
            }
            return Users.Remove(userToRemove);
        }

        public bool Exist(User userAsked) {
            if (userAsked == null) {
                throw new ArgumentNullException();
            }
            return Users.Contains(userAsked);
        }

        public void Empty() {
            Users = new List<User>();
            Users.Add(new Admin("admin", "admin", "admin", "admin", DateTime.Now));
        }

        public IEnumerator<User> GetEnumerator() {
            return Users.GetEnumerator();
        }

        public Client GetClient(User userAsked) {
            if (!(userAsked is Client)) {
                throw new InvalidCastException();
            }
            Client clientAsked = (Client)Users.First(x => userAsked.Equals(x));
            return clientAsked;
        }

        public Admin GetAdmin(User userAsked) {
            if (!(userAsked is Admin)) {
                throw new InvalidCastException();
            }
            Admin adminAsked = (Admin)Users.First(x => userAsked.Equals(x));
            return adminAsked;
        }

        public Designer GetDesigner(User userAsked) {
            if (!(userAsked is Designer)) {
                throw new InvalidCastException();
            }
            Designer designerAsked = (Designer)Users.First(x => userAsked.Equals(x));
            return designerAsked;
        }

        public User GetUser(User userAsked) {
            return Users.First(x => userAsked.Equals(x));
        }

        public User GetUserByUserName(string userName) {
            return Users.First(x => x.UserName == userName);
        }
    }
}