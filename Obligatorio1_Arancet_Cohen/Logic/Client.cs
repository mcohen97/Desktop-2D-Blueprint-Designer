using System;
using System.Collections.Generic;

namespace Logic
{
    public class Client : User
    {
      
        public string Phone { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }

        public Client() {
            Permissions = GeneratePermissions();
        }

        public Client(string name, string surname, string userName, string password, string phone, string address, string id, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            Phone = phone;
            Address = address;
            Id = id;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;

            Permissions = GeneratePermissions();
        }

        private List<Permission> GeneratePermissions() {
            List<Permission> perms=new List<Permission>();
            perms.Add(Permission.READ_BLUEPRINT);
            perms.Add(Permission.HOLD_EXTRA_DATA);
            perms.Add(Permission.FIRST_LOGIN);
            perms.Add(Permission.HAVE_BLUEPRINT);
            perms.Add(Permission.EDIT_OWN_DATA);
            return perms;
        }
    }

    
}