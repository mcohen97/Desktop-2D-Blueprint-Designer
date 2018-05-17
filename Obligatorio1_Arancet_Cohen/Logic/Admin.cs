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

            Permissions = new List<Permission>();
            Permissions.Add(Permission.CREATE_USER);
            Permissions.Add(Permission.EDIT_USER);
            Permissions.Add(Permission.READ_USER);
            Permissions.Add(Permission.REMOVE_USER);
            Permissions.Add(Permission.MANAGE_COSTS);
            Permissions.Add(Permission.EDIT_OWN_DATA);
        }
    }
}