using System;
using System.Collections.Generic;

namespace Obligatorio1_Arancet_Cohen
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