using System;
using System.Collections.Generic;

namespace Obligatorio1_Arancet_Cohen
{
    public class Designer : User
    {
       
        public Designer(string name, string surname, string userName, string password, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;

            permissions = new List<Permission>();
            permissions.Add(Permission.CREATE_BLUEPRINT);
            permissions.Add(Permission.EDIT_BLUEPRINT);
            permissions.Add(Permission.DELETE_BLUEPRINT);
            permissions.Add(Permission.READ_BLUEPRINT);
        }
    }
}