using System;
using System.Collections.Generic;

namespace Logic.Domain
{
    public class Admin : User
    {
        public Admin(string name, string surname, string userName, string password, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;

            Permissions = new List<Permission>() {
            Permission.CREATE_USER,
            Permission.EDIT_USER,
            Permission.READ_USER,
            Permission.REMOVE_USER,
            Permission.MANAGE_COSTS,
            Permission.EDIT_OWN_DATA
        };

        }
    }
}