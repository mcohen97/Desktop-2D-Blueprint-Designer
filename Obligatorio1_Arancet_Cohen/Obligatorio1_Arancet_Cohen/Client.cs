using System;
using System.Collections.Generic;

namespace Obligatorio1_Arancet_Cohen
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

            permissions = new List<Permission>();
            permissions.Add(Permission.READ_BLUEPRINT);
        }
    }

    
}