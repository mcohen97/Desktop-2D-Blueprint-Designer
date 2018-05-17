using System;
using System.Collections.Generic;

namespace Logic.Domain
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
            Permissions = GeneratePermissions();
        }

        private List<Permission> GeneratePermissions()
        {
            List<Permission> perms = new List<Permission>();
            perms.Add(Permission.CREATE_BLUEPRINT);
            perms.Add(Permission.EDIT_BLUEPRINT);
            perms.Add(Permission.DELETE_BLUEPRINT);
            perms.Add(Permission.READ_BLUEPRINT);
            perms.Add(Permission.READ_USER);
            perms.Add(Permission.EDIT_OWN_DATA);
            return perms;
        }
    }
}