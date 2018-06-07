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
            List<Permission> perms = new List<Permission>() { 
            Permission.CREATE_BLUEPRINT,
            Permission.EDIT_BLUEPRINT,
            Permission.DELETE_BLUEPRINT,
            Permission.READ_BLUEPRINT,
            Permission.READ_USER,
            Permission.EDIT_OWN_DATA};
            return perms;
        }
    }
}