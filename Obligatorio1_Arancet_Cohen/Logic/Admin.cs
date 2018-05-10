using System;
using System.Collections.Generic;

namespace Logic
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
            Permissions.Add(Permission.ALL_PERMISSIONS);
        }
    }
}