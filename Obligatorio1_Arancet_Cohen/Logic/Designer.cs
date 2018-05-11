using System;
using System.Collections.Generic;

namespace Logic
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

            Permissions = new List<Permission>();
            Permissions.Add(Permission.CREATE_BLUEPRINT);
            Permissions.Add(Permission.EDIT_BLUEPRINT);
            Permissions.Add(Permission.DELETE_BLUEPRINT);
            Permissions.Add(Permission.READ_BLUEPRINT);
            Permissions.Add(Permission.EDIT_OWN_DATA);
        }
    }
}