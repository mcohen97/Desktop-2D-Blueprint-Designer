using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_Arancet_Cohen
{
    public abstract class User:IPermissible
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        protected List<Permission> permissions;

        public DateTime updateLastLoginDate()
        {
            DateTime dateOfLogin = DateTime.Now;
            LastLoginDate = dateOfLogin;
            return dateOfLogin;
        }

        public bool hasPermission(Permission permissionAsked)
        {
            bool userHasPermission = false;
            if (permissions.Contains(Permission.ALL_PERMISSIONS) || permissions.Contains(permissionAsked))
            {
                userHasPermission = true;
            }
            return userHasPermission;
        }
    }
}
