using System;
using System.Collections.Generic;

namespace Logic
{
    public class Client : User
    {
      
        public string Phone { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }

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

            Permissions = new List<Permission>();
            Permissions.Add(Permission.READ_BLUEPRINT);
            Permissions.Add(Permission.HOLD_EXTRA_DATA);
            Permissions.Add(Permission.FIRST_LOGIN);
            Permissions.Add(Permission.HAVE_BLUEPRINT);
            Permissions.Add(Permission.EDIT_OWN_DATA);
        }
    }

    
}